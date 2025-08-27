namespace WeatherMonitoring.WeatherBots.BotConfigurations;

public record HumidityConfiguration(double Treshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);