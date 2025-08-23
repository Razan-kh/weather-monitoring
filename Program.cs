using WeatherMonitoring.Parsers;
using WeatherMonitoring.IWeatherBots;

namespace WeatherMonitoring;

public class Program
{
    private const string ConfigFileName = "Configuration.json";

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter weather data:");
            var inputWeather = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputWeather))
                continue;
            InputType inputType= InputTypeDetector.Detect(inputWeather);
            var inputParser = ParserFactory.CreateParser(inputType);
            var weatherPublisher = new WeatherPublisher(inputParser);
            var configs = ConfigLoader.Load(ConfigFileName);
            var bots = BotFactory.CreateBots(configs);
            weatherPublisher.SubscribeBots(bots);
            weatherPublisher.ParseInput(inputWeather);
        }
    }
}
