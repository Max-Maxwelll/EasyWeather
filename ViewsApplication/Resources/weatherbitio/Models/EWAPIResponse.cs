using EW_API_DB.Models;

namespace ViewsApplication.Resources.weatherbitio.Models
{
    class EWAPIResponse
    {
        public StatusResponce status { get; set; }
        public CityJson[] data { get; set; }
    }
}