namespace WeatherAPI.Models
{
    public class WeatherForecast
    {
        public string ResolvedAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string TimeZone { get; set; }
        public CurrentConditions CurrentConditions { get; set; }

    }
}
