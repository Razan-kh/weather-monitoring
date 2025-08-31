using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.WeatherBots;

public class SunBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double TemperatureThreshold { get; init; }

    private readonly Action<string> _output;

    public SunBot(TemperatureConfiguration botConfiguration, Action<string>? output = null)
    {
        Message = botConfiguration.Message;
        Enabled = botConfiguration.Enabled;
        TemperatureThreshold = botConfiguration.TemperatureThreshold;
        _output = output ?? Console.WriteLine;
    }

    public void Activate() => _output(Message);

    public void Notify(WeatherData data)
    {
        if (data.Temperature > TemperatureThreshold)
        {
            Activate();
        }
    }
}