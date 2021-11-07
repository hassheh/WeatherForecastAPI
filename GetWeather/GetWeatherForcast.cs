using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.GetWeather
{
    public class GetWeatherForcast : IGetWeatherForcast
    {
        public GetWeatherForcast()
        {

        }

        public async Task<List<WeatherData>> GetStoredWeatherForcast()
        {
            List<WeatherData> WeatherData = new List<WeatherData>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                /*
                
                Azure key vault is setup to save SQL server secrets but it requires
                setting env veriables on host machine. Skipped so the solution could run when provided.
                
                 */

                //var keyVaultName = _configuration["KeyVaultName"];
                //var kvUri = "https://" + keyVaultName + ".vault.azure.net";
                //var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

                //var dataSource = await client.GetSecretAsync("DataSource");
                //builder.DataSource = dataSource.Value.ToString();
                //var userID = await client.GetSecretAsync("UserID");
                //builder.UserID = userID.Value.ToString();
                //var password = await client.GetSecretAsync("Password");
                //builder.Password = password.Value.ToString();

                builder.DataSource = "weather-service-server.database.windows.net";
                builder.UserID = "sqlWeatherServiceLogin";
                builder.Password = "O%1V3STLZin##N";
                builder.InitialCatalog = "WeatherInfo";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string saveWeatherDataSQL = @"Select Id, CityName, Country, Timezone, Description, Temperature, TemperatureMin, TemperatureMax, FeelsLike, ExceedsLimits, WeatherDate FROM Weather WHERE ExceedsLimits = 1";

                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(saveWeatherDataSQL, connection))
                    {
                        var reader = await command.ExecuteReaderAsync();
                        var parser = reader.GetRowParser<WeatherData>(typeof(WeatherData));

                        while (reader.Read())
                        {
                            var weather = parser(reader);
                            WeatherData.Add(weather);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return WeatherData;
        }
    }
}
