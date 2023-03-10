namespace backend.Services;
using backend.Models;

public interface IWeatherForecastService
{
  IEnumerable<WeatherForecast> GetWeather(int days);
}