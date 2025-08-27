namespace WeatherMonitoring.IWeatherBots.BotConfigurations;

public record TemperatureConfiguration(double TemperatureThreshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);