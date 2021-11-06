using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherInfoContext _dbContext;
        public WeatherForecastController(WeatherInfoContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WeatherData>>> Get()
        {
            var weatherData =  await _dbContext.WeatherData
                .AsNoTracking()
                .ToListAsync();

            if (weatherData.Count > 0)            
                return Ok(weatherData);            
            else
                return NotFound();

        }
    }
}
