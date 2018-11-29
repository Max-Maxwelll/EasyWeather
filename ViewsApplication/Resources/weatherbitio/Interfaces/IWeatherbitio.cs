using System.Threading.Tasks;

namespace ViewsApplication.Resources.weatherbitio.Interfaces
{
    interface IWeatherbitio<T,B>
    {
        Task<T> GetCurrentLocalizedForIdAsync(int id, Lang lang);
        Task<B> GetForecastLocalizedForIdAsync(int id, Lang lang);
        Task<B> GetHourlyLocalizedForIdAsync(int id, Lang lang);
    }
}