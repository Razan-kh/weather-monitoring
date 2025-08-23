using WeatherMonitoring.IWeatherBots.BotConfigurations;

namespace WeatherMonitoring.IWeatherBots;

public class RainBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double HumidityThreshold { get; init; }

    public RainBot(HumidityConfiguration  botConfiguration)
    {
        Message = botConfiguration.Message;
        Enabled = botConfiguration.Enabled;
        HumidityThreshold = botConfiguration.Treshold;
    }

    public void Activate() => Console.WriteLine(Message);

    public void Notify(WeatherData data)
    {
        if (data.Humidity > HumidityThreshold)
        {
            Activate();
        }
    }
}