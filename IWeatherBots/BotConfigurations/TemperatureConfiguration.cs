namespace WeatherMonitoring.IWeatherBots.BotConfigurations;

public record TemperatureConfiguration(double Treshold, string Message, bool Enabled) : BotConfiguration(Message, Enabled);