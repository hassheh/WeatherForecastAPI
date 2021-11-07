# WeatherForecastAPI

The API provides the saved data through the https://github.com/hassheh/WeatherService service.


# How to run

"dotnet run" in project directory with PowerShell,
The API call could be made to the local

# API Calls
A call to http://localhost:5000/api/WeatherForecast? will return all the saved data. 
There could be differnet filter options that could be added to fetch the more accurate data.

{
    "id": 21,
    "cityName": "Espoo",
    "country": "FI",
    "timezone": 7200,
    "description": "broken clouds",
    "temperature": -6.7900000000000205,
    "temperatureMin": -5.660000000000025,
    "temperatureMax": -6.7900000000000205,
    "feelsLike": -5.860000000000014,
    "exceedsLimits": true,
    "weatherDate": "2021-11-04T21:00:00"
}
