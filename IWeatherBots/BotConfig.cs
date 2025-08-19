namespace weather_monitoring.IWeatherBots;

public class BotConfig
{
    public required bool Enabled { get; set; }
    public double? TemperatureThreshold { get; set; }
    public double? HumidityThreshold { get; set; }
    public required string Message { get; set; }
}