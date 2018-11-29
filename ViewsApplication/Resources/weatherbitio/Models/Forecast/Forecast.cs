namespace ViewsApplication.Resources.weatherbitio.Models
{
    class Forecast
    {
        public string city_name { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public Data[] data { get; set; }
    }
}