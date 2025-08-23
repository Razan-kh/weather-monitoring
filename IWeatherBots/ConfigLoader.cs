using System.Text.Json;
using  WeatherMonitoring.IWeatherBots.BotConfigurations;

namespace WeatherMonitoring.IWeatherBots;

public static class ConfigLoader
{
    public static Dictionary<BotType, BotConfiguration> Load(string path)
    {
        var json = File.ReadAllText(path);
        using var doc = JsonDocument.Parse(json);

        var result = new Dictionary<BotType, BotConfiguration>();

        foreach (var property in doc.RootElement.EnumerateObject())
        {
            if (!Enum.TryParse<BotType>(property.Name, ignoreCase: true, out var botType))
            {
                throw new InvalidOperationException($"Unknown bot type in configuration: {property.Name}");
            }
            result[botType] = DeserializeBot(property);
        }

        return result;
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