namespace backend.Services.Impl;
using backend.Models;

public class WeatherForecastService : IWeatherForecastService
{
  private static readonly string[] Summaries = new[]
  {
    "freezing","hot","cold"
  };
  private readonly ILogger<WeatherForecastService> _logger;

  public WeatherForecastService(ILogger<WeatherForecastService> logger){
    _logger = logger;
    _logger.LogInformation("object created from WeatherForecastService");
  }

  public IEnumerable<WeatherForecast> GetWeather(int days)
  {
    return Enumerable.Range(1, days).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
        .ToArray();
  }
}