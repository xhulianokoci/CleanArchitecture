using CleanArchitecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
    Task<WeatherForecast> GetWeatherForecastByIdAsync(int id);
    Task AddWeatherForecastAsync(WeatherForecast forecast);
    Task UpdateWeatherForecastAsync(WeatherForecast forecast);
    Task DeleteWeatherForecastAsync(int id);
}
