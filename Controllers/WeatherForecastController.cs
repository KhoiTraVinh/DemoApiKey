using ApiKey.Data;
using ApiKey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiKey.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApiKeyDbContext _apiKeyDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApiKeyDbContext apiKeyDbContext)
    {
        _logger = logger;
        _apiKeyDbContext = apiKeyDbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<ApiKeyModel>> Get()
    {
        return await _apiKeyDbContext.ApiKeys.ToListAsync();
    }
}
