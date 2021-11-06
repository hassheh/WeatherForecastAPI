using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI
{
    public partial class WeatherInfoContext : DbContext
    {
        public WeatherInfoContext()
        { }

        public WeatherInfoContext(DbContextOptions<WeatherInfoContext> options) : base(options)
        {

        }

        public virtual DbSet<WeatherData> WeatherData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "service-1.0.0");

            modelBuilder.Entity<WeatherData>(entity =>
            {
                entity.ToTable("Weather");
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.CityName).HasColumnName("CityName");
                entity.Property(e => e.Country).HasColumnName("Country");
                entity.Property(e => e.Timezone).HasColumnName("Timezone");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.TemperatureMin).HasColumnName("TemperatureMin");
                entity.Property(e => e.TemperatureMax).HasColumnName("TemperatureMax");
                entity.Property(e => e.FeelsLike).HasColumnName("FeelsLike");
                entity.Property(e => e.ExceedsLimits).HasColumnName("ExceedsLimits");
                entity.Property(e => e.WeatherDate).HasColumnName("WeatherDate");
                entity.Property(e => e.Temperature).HasColumnName("Temperature"); 
            });
        }
    }
}
