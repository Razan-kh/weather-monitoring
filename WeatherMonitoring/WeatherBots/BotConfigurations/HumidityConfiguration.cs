namespace WeatherMonitoring.WeatherBots.BotConfigurations;

public record HumidityConfiguration(double HumidityThreshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);