namespace WeatherMonitoring.IWeatherBots.BotConfigurations;

public record HumidityConfiguration(double HumidityThreshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);