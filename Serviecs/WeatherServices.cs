using System.Net.Http.Json;
using System.Text.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Serviecs
{
    public class WeatherServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _APIKey;

        public WeatherServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _APIKey = configuration["WeatherAPI:APIKey"];
            _httpClient.BaseAddress = new Uri(configuration["WeatherAPI:APIUrl"]);
        }

        public async Task<WeatherForecast>GetWeatherAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{city}/today?key={_APIKey}&include=current&contentType=json");

                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<WeatherForecast>();
                
                return result;
            }

            catch (HttpRequestException ex)
            {
                throw new WeatherServicesException("Unable to retrieve weather data", ex);
            }

            catch (JsonException ex)
            {
                throw new WeatherServicesException("Json Error", ex);
            }
        }
    }
}
