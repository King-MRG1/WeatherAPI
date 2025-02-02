
namespace WeatherAPI.Serviecs
{
    [Serializable]
    internal class WeatherServicesException : Exception
    {
        public WeatherServicesException()
        {
        }

        public WeatherServicesException(string? message) : base(message)
        {
        }

        public WeatherServicesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}