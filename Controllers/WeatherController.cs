using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeatherAPI.Caches;
using WeatherAPI.Dto;
using WeatherAPI.Models;
using WeatherAPI.Serviecs;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherServices _weatherServices;
        private readonly IDistributedCache _cache;
        public WeatherController(WeatherServices weatherServices, IDistributedCache cache)
        {
            _weatherServices = weatherServices;
            _cache = cache;
        }

        [HttpGet("{city}")]

        public async Task<IActionResult> GetWeather(string city)
        {
            try
            {
                string Loadlocation = "";

                string cacheKey = $"Weather_{city}";

                var weatherView = await _cache.GetRecordAsync<WeatherForecast>(cacheKey);

                if(weatherView is null)
                {
                   weatherView = await _weatherServices.GetWeatherAsync(city);

                   Loadlocation = "DataBase";

                   await _cache.SetRecordAsync(cacheKey, weatherView);
                }

                else
                    Loadlocation = "Cache";

                Response.Headers.Append("Load-Location", Loadlocation);

                var weather = MappingWeather.ToWeatherViewDto(weatherView);

                return Ok(weather);
            }

            catch (WeatherServicesException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
