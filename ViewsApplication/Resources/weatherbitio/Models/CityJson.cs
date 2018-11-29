using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EW_API_DB.Models
{
    public class CityJson
    {
        public int id { get; set; }
        public int city_id { get; set; }
        public string city_name { get; set; }
        public string state_code { get; set; }
        public string state_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
    }
}