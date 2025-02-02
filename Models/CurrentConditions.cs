namespace WeatherAPI.Models
{
    public class CurrentConditions
    {
        public string Datetime { get; set; }
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public string Conditions { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal DatetimeEpoch { get; set; }
    }
}
