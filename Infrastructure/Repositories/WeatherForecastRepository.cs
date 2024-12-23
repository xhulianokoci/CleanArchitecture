using CleanArchitecture;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WeatherForecastRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
    {
        return await _dbContext.WeatherForecasts.ToListAsync();
    }

    public async Task<WeatherForecast> GetByIdAsync(int id)
    {
        return await _dbContext.WeatherForecasts.FindAsync(id);
    }

    public async Task AddAsync(WeatherForecast forecast)
    {
        await _dbContext.WeatherForecasts.AddAsync(forecast);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(WeatherForecast forecast)
    {
        _dbContext.WeatherForecasts.Update(forecast);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var forecast = await _dbContext.WeatherForecasts.FindAsync(id);
        if (forecast != null)
        {
            _dbContext.WeatherForecasts.Remove(forecast);
            await _dbContext.SaveChangesAsync();
        }
    }
}
