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
            property => DeserializeBot(property)
        );
    }

    private static BotConfiguration DeserializeBot(JsonProperty property)
    {
        if (property.Name.Equals("RainBot", StringComparison.OrdinalIgnoreCase))
        {
            return property.Value.Deserialize<HumidityConfiguration>()!;
        }
        else if (property.Name.Equals("SunBot", StringComparison.OrdinalIgnoreCase))
        {
            return property.Value.Deserialize<TemperatureConfiguration>()!;
        }
        else if (property.Name.Equals("SnowBot", StringComparison.OrdinalIgnoreCase))
        {
            return property.Value.Deserialize<TemperatureConfiguration>()!;
        }

        return property.Value.Deserialize<BotConfiguration>()!;
    }
}