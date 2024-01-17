
using DSharpPlus;
using DSharpPlus.EventArgs;

public class Worker : BackgroundService
{
    private readonly DiscordClient _discordClient;

    public Worker(DiscordClient discordClient)
    {
        _discordClient = discordClient;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _discordClient.MessageCreated += OnMessageCreated;
        await _discordClient.ConnectAsync();
    }

    public async Task OnMessageCreated(DiscordClient discordClient, MessageCreateEventArgs e)
    {
        if(e.Message.Content == "Ping")
            await e.Message.RespondAsync("Đào Ngu");
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _discordClient.MessageCreated -= OnMessageCreated;
        await _discordClient.DisconnectAsync();
        _discordClient.Dispose();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }


}