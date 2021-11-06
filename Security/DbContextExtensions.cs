using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecastAPI.Security
{
    public class DbContextExtensions
    {
        public DbContextOptions<WeatherInfoContext> DbContextOptionsFactory(IServiceProvider provider)
        {
            var connectionString = GetConnectionStringFromHeader(provider);
            var optionsBuilder = new DbContextOptionsBuilder<WeatherInfoContext>();
            optionsBuilder.UseSqlServer(connectionString).UseInternalServiceProvider(provider);

            return optionsBuilder.Options;
        }

        private string GetConnectionStringFromHeader(IServiceProvider provider)
        {
            return "Server=weather-service-server.database.windows.net;Uid=sqlWeatherServiceLogin;Password=O%1V3STLZin##N;Database=WeatherInfo;Connection Timeout=60";
        }
    }
}
