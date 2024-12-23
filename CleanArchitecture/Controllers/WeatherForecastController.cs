using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var forecasts = await _service.GetWeatherForecastsAsync();
        return Ok(forecasts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var forecast = await _service.GetWeatherForecastByIdAsync(id);
        if (forecast == null) return NotFound();

        return Ok(forecast);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WeatherForecast forecast)
    {
        await _service.AddWeatherForecastAsync(forecast);
        return CreatedAtAction(nameof(Get), new { id = forecast.Id }, forecast);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] WeatherForecast forecast)
    {
        if (id != forecast.Id) return BadRequest();

        await _service.UpdateWeatherForecastAsync(forecast);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteWeatherForecastAsync(id);
        return NoContent();
    }
}
