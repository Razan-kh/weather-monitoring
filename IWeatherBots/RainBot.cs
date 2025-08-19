namespace weather_monitoring.IWeatherBots;

public class RainBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double HumidityThreshold { get; init; }

    public RainBot(BotConfig botConfig)
    {
        Message = botConfig.Message;
        Enabled = botConfig.Enabled;
        HumidityThreshold = (double)botConfig.HumidityThreshold!;
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