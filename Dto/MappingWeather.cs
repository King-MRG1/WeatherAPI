using WeatherAPI.Models;

namespace WeatherAPI.Dto
{
    public static class MappingWeather
    {
        public static WeatherViewDto ToWeatherViewDto(WeatherForecast weatherForecast)
        {
            return new WeatherViewDto
            {
                ResolvedAddress = weatherForecast.ResolvedAddress,
                Latitude = weatherForecast.Latitude,
                Longitude = weatherForecast.Longitude,
                TimeZone = weatherForecast.TimeZone,
                Datetime = weatherForecast.CurrentConditions.Datetime,
                FeelsLike = weatherForecast.CurrentConditions.FeelsLike,
                Temp = weatherForecast.CurrentConditions.Temp,
                Humidity = weatherForecast.CurrentConditions.Humidity,
                WindSpeed = weatherForecast.CurrentConditions.WindSpeed,
                DatetimeEpoch = weatherForecast.CurrentConditions.DatetimeEpoch,
                Conditions = weatherForecast.CurrentConditions.Conditions,
            };
        }
    }
}
