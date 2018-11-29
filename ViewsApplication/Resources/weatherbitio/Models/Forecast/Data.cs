namespace ViewsApplication.Resources.weatherbitio.Models
{
    class Data
    {
        public string datetime { get; set; }
        public long ts { get; set; }
        public float snow { get; set; }
        public float snow_depth { get; set; }

        public float snow6h { get; set; }

        public float precip { get; set; }
        public float temp { get; set; }
        public float dewpt { get; set; }
        public float max_temp { get; set; }
        public float min_temp { get; set; }

        public float app_temp { get; set; }

        public float app_max_temp { get; set; }
        public float app_min_temp { get; set; }
        public float rh { get; set; }
        public float clouds { get; set; }
        public Weather weather { get; set; }
        public float slp { get; set; }
        public float pres { get; set; }
        public float uv { get; set; }
        public string max_dhi { get; set; }
        public float vis { get; set; }
        public float pop { get; set; }
        public float moon_phase { get; set; }
        public long sunrise_ts { get; set; }
        public long sunset_ts { get; set; }
        public long moonrise_ts { get; set; }
        public long moonset_ts { get; set; }
        public string pod { get; set; }
        public float wind_spd { get; set; }
        public float wind_dir { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
    }
}