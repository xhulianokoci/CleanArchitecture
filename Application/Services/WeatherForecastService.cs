using Application.Interfaces;
using CleanArchitecture;
using Infrastructure.Persistence;

namespace Application.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastRepository _repository;

    public WeatherForecastService(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddWeatherForecastAsync(WeatherForecast forecast)
    {
        await _repository.AddAsync(forecast);
    }

    public async Task UpdateWeatherForecastAsync(WeatherForecast forecast)
    {
        await _repository.UpdateAsync(forecast);
    }

    public async Task DeleteWeatherForecastAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}