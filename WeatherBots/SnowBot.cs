using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.WeatherBots;

public class SnowBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double TemperatureThreshold { get; init; }

    public SnowBot(TemperatureConfiguration botConfiguration)
    {
        Message = botConfiguration.Message;
        Enabled = botConfiguration.Enabled;
        TemperatureThreshold = botConfiguration.TemperatureThreshold;
    }

    public void Activate() => Console.WriteLine(Message);

    public void Notify(WeatherData data)
    {
        if (data.Temperature < TemperatureThreshold)
        {
            Activate();
        }
    }
}