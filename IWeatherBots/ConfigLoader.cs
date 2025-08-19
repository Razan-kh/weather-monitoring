using System.Text.Json;

namespace weather_monitoring.IWeatherBots;

public static class ConfigLoader
{
    public static Dictionary<string, BotConfig> Load(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Dictionary<string, BotConfig>>(json);
    }
}