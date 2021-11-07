using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.GetWeather
{
    public interface IGetWeatherForcast
    {
        Task<List<WeatherData>> GetStoredWeatherForcast();
    }
}
