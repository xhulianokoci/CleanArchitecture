using CleanArchitecture;

namespace Infrastructure.Persistence;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetAllAsync();
    Task<WeatherForecast> GetByIdAsync(int id);
    Task AddAsync(WeatherForecast forecast);
    Task UpdateAsync(WeatherForecast forecast);
    Task DeleteAsync(int id);
}
