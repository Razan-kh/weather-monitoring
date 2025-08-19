using weather_monitoring.IWeatherBots;
using weather_monitoring.ParsingInput;

namespace weather_monitoring;

public class MainClass
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter weather data:");
            var inputWeather = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputWeather))
                continue;
            var inputParser = ParserFactory.CreateParser(inputWeather);
            var weatherPublisher = new WeatherPublisher(inputParser);
            var configs = ConfigLoader.Load("Configuration.json");
            var bots = BotFactory.CreateBots(configs);
            weatherPublisher.SubscribeBots(bots);
            weatherPublisher.ParseInput(inputWeather);
        }
    }
}