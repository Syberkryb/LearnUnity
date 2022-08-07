using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly string weatherForecastKey = "weatherForecastKey";

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        IEnumerable<WeatherForecast> weatherForecastCollection = null;
        
        // If found in cache, return cached data
        if (_memoryCache.TryGetValue(weatherForecastKey, out weatherForecastCollection))
        {
            return weatherForecastCollection;
        }

        // If not found, then calculate response
        weatherForecastCollection = GetWeatherForecast();
        
        // Set cache options
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30));

        // Set object in cache
        _memoryCache.Set(weatherForecastKey, weatherForecastCollection, cacheOptions);
        return weatherForecastCollection;
    }

    private static IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
