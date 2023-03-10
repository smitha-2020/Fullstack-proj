using backend.Models;

namespace backend.Services;

public interface IWeatherForecastService
{
  IEnumerable<WeatherForecast> GetWeather(int days);
}