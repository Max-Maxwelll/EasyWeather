using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Views;
using Android.Net;
using System.Net.Http;
using ViewsApplication.Resources.weatherbitio;
using Android.Support.V7.View.Menu;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EW_API_DB.Models;
using System.Collections.Generic;
using ViewsApplication.Adapters;
using Android.Support.Design.Widget;

namespace ViewsApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        View activity_main;
        Button snack_bar;
        ConnectivityManager cm;
        TextView textView;
        TextInputEditText city;
        ListView listView;
        List<string> listViewStrings;

        //private APIXURestApi aPIXURestApi = new APIXURestApi("893f888543ac4dd8a1b195606182810");
        private Weatherbitio weatherbitio = new Weatherbitio("0b9c2bef62a34f008c77d646fa374829");
        private EasyWeatherAPI easyWeatherAPI = new EasyWeatherAPI("123");
        public bool isConnected { get; private set; }
        private HttpClient client = new HttpClient();
        private CityJson[] cityJsons;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            cm = (ConnectivityManager)GetSystemService(ConnectivityService);

            try
            {
                isConnected = cm.ActiveNetworkInfo.IsConnected;
            }
            catch (Exception ex)
            {
                ShowToast("Is Not Connected!");
            }
                
            activity_main = FindViewById<View>(Resource.Id.activity_main);
            SetContentView(Resource.Layout.activity_main);
            snack_bar = FindViewById<Button>(Resource.Id.snackBtn);
            textView = FindViewById<TextView>(Resource.Id.textView1);
            city = FindViewById<TextInputEditText>(Resource.Id.textInputCity);
            listView = FindViewById<ListView>(Resource.Id.listView1);
            listViewStrings = new List<string>();

            listView.ItemClick += ListItemClick;
            listView.ItemClick += ListView_ItemClick;
            snack_bar.Click += ShowSnackBar;
        }

        private async void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var current = await weatherbitio.GetCurrentLocalizedForIdAsync(cityJsons[e.Position].city_id, Lang.ru);
            var forecast = await weatherbitio.GetForecastLocalizedForIdAsync(cityJsons[e.Position].city_id, Lang.ru);
            var hourly = await weatherbitio.GetHourlyLocalizedForIdAsync(cityJsons[e.Position].city_id, Lang.ru);
            listView.SetAdapter(null);
            textView.Text = "Дата: " + current.datetime + "\n";
            textView.Text += "" + current.weather.description + "\n";
            textView.Text += "Локация: " + current.city_name + ", " + current.country_code + "\n";
            textView.Text += "Облачность: " + current.clouds + " %\n";
            textView.Text += "Температура: " + current.temp + "C\n";
            textView.Text += "Скорость ветра: " + current.wind_spd + " m\n";
            textView.Text += "Направление: " + current.wind_cdir_full + "\n";
            textView.Text += "16 дней -> " + forecast.data.Length + " дней получено\n";
            textView.Text += "48 часов -> " + hourly.data.Length + " часов получено\n";
        }

        public void ShowToast(string message)
        {
            Toast toast = Toast.MakeText(this, message, ToastLength.Long);
            toast.SetGravity(GravityFlags.Bottom, 0, 0);
            //toast.SetMargin(0, 10);
            toast.Show();
        }
        public async void ShowSnackBar(object sender, EventArgs args)
        {
            if (isConnected)
            {
                #region
                //HttpRequestMessage request = new HttpRequestMessage()
                //{
                //    RequestUri = new System.Uri("http://api.weatherbit.io/v2.0/current?key=0b9c2bef62a34f008c77d646fa374829&lang=ru&city=" + city.Text),
                //    Method = HttpMethod.Get
                //};
                //request.Headers.Add("Accept", "application/json");
                //HttpResponseMessage response = await client.SendAsync(request);

                //APIXUForecastWeather forecast = null;
                //Current response = null;

                //try
                //{
                //    forecast = await aPIXURestApi.GetForecastWeatherLocalizedAsync(city.Text, 10, APIXUL10n.Russian);
                //    response = forecast.Current;

                //    string location = forecast.Location.Country + " " + forecast.Location.Name;
                //    string description = response.Condition.Text + "\n";
                //    string loc = "Локация: " + location + "\n";
                //    string tempC = "Температура " + response.TempC + " C\n";
                //    string cloud = "Облачность " + response.Cloud + " %";
                //    string days = "";

                //    textView.Text = description + loc + tempC + cloud + "\n" + days;
                //}
                //catch(Exception ex)
                //{
                //    ShowToast(ex.Message + " " + ex.StackTrace);
                //}
                #endregion
                try
                {
                    var cities = await easyWeatherAPI.GetCities(city.Text);
                    StatusResponce statusResponce = cities.status;
                    cityJsons = cities.data;
                    if(statusResponce.Code != 200)
                    {
                        if(statusResponce.Code == 500)
                        {
                            ShowToast(statusResponce.Message + "\n" + statusResponce.StackTrace);
                        }
                        else ShowToast(statusResponce.Message);
                        return;
                    }

                    textView.Text = "";
                    listViewStrings.Clear();

                    CityViewAdapter adapterView = new CityViewAdapter(this, cityJsons);

                    listView.Adapter = adapterView;

                    
                }
                catch (Exception ex)
                {
                    //ShowToast("Город не найден");
                    ShowToast(ex.Message + "\n" + ex.StackTrace);
                }
                
            }
        }
        public void ClickCheckBox(object sender, EventArgs eventArgs)
        {
            if(((CheckBox)sender).Checked)
            {
                CheckBox checkBox = (CheckBox)sender;
                string message = "You selected " + checkBox.Text;
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#ff01a361"));
                Toast toast = Toast.MakeText(this, message, ToastLength.Long);
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
            }
        }
        public void ListItemClick(object sender, EventArgs eventArgs)
        {
            //Adapter item = (Adapter)sender;
            
        }
    }
}