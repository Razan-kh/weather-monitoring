using WeatherMonitoring.Parsers;
using WeatherMonitoring.IWeatherBots;
using WeatherMonitoring.Parsers.Exceptions;

namespace WeatherMonitoring;

public class Program
{
    private const string ConfigFileName = "Configuration.json";

    public static void Main()
    {
        var configs = ConfigLoader.Load(ConfigFileName);
        var bots = BotFactory.CreateBots(configs);

        while (true)
        {
            var inputWeather = ReadWeatherInput();
            if (inputWeather is null)
            {
                continue;
            }

            if (!TryDetectInputType(inputWeather, out var inputType))
            {
                continue;
            }

            var inputParser = ParserFactory.CreateParser(inputType);
            var weatherPublisher = new WeatherPublisher(inputParser);
            weatherPublisher.SubscribeBots(bots);

            TryParseInput(weatherPublisher, inputWeather);
        }
    }

    private static string? ReadWeatherInput()
    {
        Console.WriteLine("Enter weather data:");
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }

    private static bool TryDetectInputType(string inputWeather, out InputType inputType)
    {
        try
        {
            inputType = InputTypeDetector.Detect(inputWeather);
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Input type detection failed: {exception.Message}");
            inputType = default;
            return false;
        }
    }

    private static void TryParseInput(WeatherPublisher weatherPublisher, string inputWeather)
    {
        try
        {
            weatherPublisher.ParseInput(inputWeather);
        }
        catch (ParsingException exception)
        {
            Console.WriteLine($"Parsing failed: {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Unexceptionpected error: {exception.Message}");
        }
    }
}