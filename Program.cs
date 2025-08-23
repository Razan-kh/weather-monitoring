using WeatherMonitoring.Parsers;
using WeatherMonitoring.IWeatherBots;
using WeatherMonitoring.Parsers.Exceptions;

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
            InputType inputType;
            try
            {
                inputType = InputTypeDetector.Detect(inputWeather);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
                continue;
            }
            var inputParser = ParserFactory.CreateParser(inputType);
            var weatherPublisher = new WeatherPublisher(inputParser);
            var configs = ConfigLoader.Load(ConfigFileName);
            var bots = BotFactory.CreateBots(configs);
            weatherPublisher.SubscribeBots(bots);
            try
            {
                weatherPublisher.ParseInput(inputWeather);
            }
            catch (ParsingException ex)
            {
                Console.WriteLine($"Parsing failed: {ex.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}");
            }
        }
    }
}
