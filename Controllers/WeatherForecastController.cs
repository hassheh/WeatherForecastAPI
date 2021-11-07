using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastAPI.GetWeather;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController] 
    public class WeatherForecastController : ControllerBase
    {
        public IGetWeatherForcast _getWeatherForcast { get; set; }

        public WeatherForecastController(IGetWeatherForcast _getWeatherForcast)
        {
            this._getWeatherForcast = _getWeatherForcast;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherData>>> Get()
        {
            var weatherData = await _getWeatherForcast.GetStoredWeatherForcast();
            
            if (weatherData.Count > 0)
                return Ok(weatherData);            
            else
                return NotFound();
        }
    }
}
