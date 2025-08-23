namespace WeatherMonitoring.IWeatherBots.BotConfigurations;

public record HumidityConfiguration(double Treshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);