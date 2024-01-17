using ApiKey.Data;
using ApiKey.Models;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiKey.Controllers;

[ApiController]
[Route("api/key")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DiscordClient _discordClient;
    private readonly ApiKeyDbContext _apiKeyDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApiKeyDbContext apiKeyDbContext, DiscordClient discordClient)
    {
        _logger = logger;
        _apiKeyDbContext = apiKeyDbContext;
        _discordClient = discordClient;
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

    [HttpPost("Commit")]
    public async Task Commit()
    {
        var channel = await _discordClient.GetChannelAsync(1197100928533282832);
        await _discordClient.SendMessageAsync(channel, "Khôi Dev Đã Tạo Cồm Mít");
    }
}
