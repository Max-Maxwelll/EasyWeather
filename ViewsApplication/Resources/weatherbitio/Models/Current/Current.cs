using System;
namespace ViewsApplication.Resources.weatherbitio.Models
{
    class Current
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string timezone { get; set; }
        public string station { get; set; }
        public string ob_time { get; set; }
        public string datetime { get; set; }
        public long ts { get; set; }
        public string city_name { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public float press { get; set; }
        public float slp { get; set; }
        public float wind_spd { get; set; }
        public float wind_dir { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public float temp { get; set; }
        public float app_temp { get; set; }
        public float rh { get; set; }
        public float dewpt { get; set; }
        public float clouds { get; set; }
        public string pod { get; set; }
        public Weather weather { get; set; }
        public float vis { get; set; }
        public string precip { get; set; }
        public float uv { get; set; }
        public float dhi { get; set; }
        public float elev_angle { get; set; }
        public float h_angle { get; set; }
    }
}