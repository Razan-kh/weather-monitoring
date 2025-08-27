using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.WeatherBots;

public static class BotFactory
{
    public static List<IWeatherBot> CreateBots(Dictionary<BotType, BotConfiguration> configs)
    {
        return configs
        .Where(kvp => kvp.Value.Enabled)
        .Select(kvp => CreateBot(kvp.Key, kvp.Value))
        .ToList();                                     
    }

    public static IWeatherBot CreateBot(BotType botName, BotConfiguration config)
    {
        return botName switch
        {
            BotType.RainBot => new RainBot((HumidityConfiguration)config),
            BotType.SunBot  => new SunBot((TemperatureConfiguration)config),
            BotType.SnowBot => new SnowBot((TemperatureConfiguration)config),
            _ => throw new ArgumentOutOfRangeException(nameof(botName), botName, "Unsupported bot type")
        };
    }
}