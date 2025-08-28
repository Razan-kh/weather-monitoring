using System.Text.Json;

using WeatherMonitoring.Enums;
using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.WeatherBots;

public static class ConfigLoader
{
    public static Dictionary<BotType, BotConfiguration> Load(string path)
    {
        var json = File.ReadAllText(path);
        using var doc = JsonDocument.Parse(json);
        
        return doc.RootElement
        .EnumerateObject()
        .ToDictionary(
            property => Enum.TryParse<BotType>(property.Name, ignoreCase: true, out var botType)
                ? botType
                : throw new InvalidOperationException($"Unknown bot type in configuration: {property.Name}"),
            DeserializeBot
        );
    }

    private static BotConfiguration DeserializeBot(JsonProperty property)
    {
        if (!Enum.TryParse<BotType>(property.Name, ignoreCase: true, out var botType))
        {
            throw new InvalidOperationException($"Unknown bot type: {property.Name}");
        }

        return botType switch
        {
            BotType.RainBot => property.Value.Deserialize<HumidityConfiguration>()!,
            BotType.SunBot => property.Value.Deserialize<TemperatureConfiguration>()!,
            BotType.SnowBot => property.Value.Deserialize<TemperatureConfiguration>()!,
            _ => property.Value.Deserialize<BotConfiguration>()!
        };
    }
}