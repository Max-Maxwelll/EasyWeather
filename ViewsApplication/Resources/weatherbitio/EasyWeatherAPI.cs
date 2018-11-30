using System.Net.Http;
using System.Threading.Tasks;
using EW_API_DB.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ViewsApplication.Resources.weatherbitio.Models;

namespace ViewsApplication.Resources.weatherbitio
{
    class EasyWeatherAPI
    {
        private HttpClient httpClient = new HttpClient();
        //private string key { get; set; }
        private static string ewApiUrl { get; set; }

        public EasyWeatherAPI(string key)
        {
            //this.key = key;
            ewApiUrl = "http://maxwell.somee.com/api/cities/" + key + "/@";
        }
        public async Task<EWAPIResponse> GetCities(string name)
        {  
            name = name.Trim();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new System.Uri(ewApiUrl + name);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            //JObject json = JObject.Parse(content);
            //JToken jtoken = json.SelectToken(@"$.data");

            return JsonConvert.DeserializeObject<EWAPIResponse>(content);
        }
    }
}