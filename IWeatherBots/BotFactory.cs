namespace weather_monitoring.IWeatherBots;

public static class BotFactory
{
    public static List<IWeatherBot> CreateBots(Dictionary<string, BotConfig> configs)
    {
        var bots = new List<IWeatherBot>();

        foreach (var kvp in configs)
        {
            var botName = kvp.Key;
            var config = kvp.Value;

            if (!config.Enabled)
            {
                continue;
            }
            var bot = CreateBot(botName, config);
            bots.Add(bot);
        }
        return bots;
    }

    public static IWeatherBot CreateBot(string botName, BotConfig config)
    {
        IWeatherBot bot = botName switch
        {
            "RainBot" => new RainBot(config),
            "SunBot" => new SunBot(config),
            "SnowBot" => new SnowBot(config),
            _ => throw new Exception($"Unknown bot type: {botName}"),
        };
        return bot;
    }
}