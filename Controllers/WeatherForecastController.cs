using ApiKey.Data;
using ApiKey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiKey.Controllers;

[ApiController]
[Route("api/key")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApiKeyDbContext _apiKeyDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApiKeyDbContext apiKeyDbContext)
    {
        _logger = logger;
        _apiKeyDbContext = apiKeyDbContext;
        _logger.LogInformation("WeatherForecast controller called ");
    }

    [HttpGet("GetWeatherForecast")]
    public async Task<IEnumerable<ApiKeyModel>> Get()
    {
        _logger.LogInformation("WeatherForecast get method Starting.");
        return await _apiKeyDbContext.ApiKeys.ToListAsync();
    }

    [HttpPost("AddWeatherForecast")]
    public async Task<ApiKeyModel> Add([FromBody] ApiKeyModel model)
    {
        await _apiKeyDbContext.ApiKeys.AddAsync(model);
        await _apiKeyDbContext.SaveChangesAsync();
        return model;
    }
}
