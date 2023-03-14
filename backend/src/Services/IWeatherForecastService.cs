using backend.src.Models;

namespace backend.src.Services;

public interface IWeatherForecastService
{
  IEnumerable<WeatherForecast> GetWeather(int days);
}