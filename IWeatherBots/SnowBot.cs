namespace weather_monitoring.IWeatherBots;

public class SnowBot : IWeatherBot
{
    public string Message { get; init; }
    public bool Enabled { get; init; }
    public double TemperatureThreshold { get; init; }

    public SnowBot(BotConfig botConfig)
    {
        Message = botConfig.Message;
        Enabled = botConfig.Enabled;
        TemperatureThreshold = (double)botConfig.TemperatureThreshold!;
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