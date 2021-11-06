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
        private readonly IConfiguration _config;
        
        public DbContextExtensions(IConfiguration _config)
        {
            this._config = _config;
        }
        
        public DbContextOptions<WeatherInfoContext> DbContextOptionsFactory(IServiceProvider provider)
        {
            var connectionString = GetConnectionStringFromHeader(provider);
            var optionsBuilder = new DbContextOptionsBuilder<WeatherInfoContext>();
            optionsBuilder.UseSqlServer(connectionString).UseInternalServiceProvider(provider);

            return optionsBuilder.Options;
        }

        private string GetConnectionStringFromHeader(IServiceProvider provider)
        {
            return _config["Weather:ConnectionString"];
        }
    }
}
