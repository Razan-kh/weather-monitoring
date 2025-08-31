using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.WeatherBots;

public class RainBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double HumidityThreshold { get; init; }

    private readonly Action<string> _output;

    public RainBot(HumidityConfiguration botConfiguration, Action<string>? output = null)
    {
        Message = botConfiguration.Message;
        Enabled = botConfiguration.Enabled;
        HumidityThreshold = botConfiguration.HumidityThreshold;
        _output = output ?? Console.WriteLine;
    }

    public void Activate() => _output(Message);

    public void Notify(WeatherData data)
    {
        if (data.Humidity > HumidityThreshold)
        {
            Activate();
        }
    }
}