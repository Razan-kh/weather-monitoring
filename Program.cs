using weather_monitoring.IWeatherBots;

public class Program
{
    public static void Main()
    {
        var configs = ConfigLoader.Load("Configuration.json");
        var bots = BotFactory.CreateBots(configs);
    }
}
