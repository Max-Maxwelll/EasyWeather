using System;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ViewsApplication.Resources.weatherbitio.Models;
using ViewsApplication.Resources.weatherbitio.Interfaces;

namespace ViewsApplication.Resources.weatherbitio
{
    class Weatherbitio : IWeatherbitio<Current, Forecast>
    {

        private HttpClient httpClient = new HttpClient();
        private ConnectivityManager connectivityManager;
        private string key;
        private string url = "https://api.weatherbit.io/v2.0/";

        public Weatherbitio(string key)
        {
            this.key = key;

        }
        //public async Task<Current> GetCurrentLocalizedAsync(string city, string country, Lang lang)
        //{
        //    city = city.Trim();
        //    country = country.Trim();
        //    HttpRequestMessage request = new HttpRequestMessage();
        //    request.RequestUri = new System.Uri(url + "?city=" + city + "&lang=" + lang.ToString("g") + "&key=" + key);
        //    request.Method = HttpMethod.Get;
        //    request.Headers.Add("Accept", "application/json");


        //    HttpResponseMessage response = await httpClient.SendAsync(request);
        //    string content = await response.Content.ReadAsStringAsync();
        //    JObject json = JObject.Parse(content);

        //    JToken jtoken = json.SelectToken(@"$.data[0]");
        //    return JsonConvert.DeserializeObject<Current>(jtoken.ToString());
        //}
        public async Task<Current> GetCurrentLocalizedForIdAsync(int id, Lang lang)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new System.Uri(url + "current?city_id=" + id + "&lang=" + lang.ToString("g") + "&key=" + key);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");


            HttpResponseMessage response = await httpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            JToken jtoken = json.SelectToken(@"$.data[0]");
            return JsonConvert.DeserializeObject<Current>(jtoken.ToString());
        }
        public async Task<Forecast> GetForecastLocalizedForIdAsync(int id, Lang lang)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new System.Uri(url + "forecast/daily?city_id=" + id + "&lang=" + lang.ToString("g") + "&key=" + key);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");


            HttpResponseMessage response = await httpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            JToken jtoken = json.SelectToken(@"$");
            return JsonConvert.DeserializeObject<Forecast>(jtoken.ToString());
        }
        public async Task<Forecast> GetHourlyLocalizedForIdAsync(int id, Lang lang)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new System.Uri(url + "/forecast/hourly?city_id=" + id + "&lang=" + lang.ToString("g") + "&key=" + key);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");


            HttpResponseMessage response = await httpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            JToken jtoken = json.SelectToken(@"$");
            return JsonConvert.DeserializeObject<Forecast>(jtoken.ToString());
        }
    }
}