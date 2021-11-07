using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.GetWeather
{
    public interface IGetWeatherForcast
    {
        Task<List<WeatherData>> GetStoredWeatherForcast();
    }
}
