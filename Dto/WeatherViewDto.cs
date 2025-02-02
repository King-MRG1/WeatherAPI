using WeatherAPI.Models;

namespace WeatherAPI.Dto
{
    public class WeatherViewDto
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ResolvedAddress { get; set; }
        public string TimeZone { get; set; }
        public string Datetime { get; set; }
        public decimal DatetimeEpoch { get; set; }
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public string Conditions { get; set; }

    }
}
