using WeatherMonitoring.Parsers;
using WeatherMonitoring.IWeatherBots;
using WeatherMonitoring.Parsers.Exceptions;
using WeatherMonitoring.Parsers.Exceptions;
using WeatherMonitoring.Parsers;

namespace WeatherMonitoring;

public class Program
{
    private const string ConfigFileName = "Configuration.json";

    public static void Main()
    {
        var configs = ConfigLoader.Load(ConfigFileName);
        var bots = BotFactory.CreateBots(configs);
        string inputWeather;
        var weatherPublisher = new WeatherPublisher();
        weatherPublisher.SubscribeBots(bots);
        WeatherData weatherData;
        while (true)
        {
            inputWeather = ReadWeatherInput();
            if (inputWeather is null)
            {
                continue;
            }

            if (!TryDetectInputType(inputWeather, out var inputType))
            {
                continue;
            }

            var inputParser = ParserFactory.CreateParser(inputType);
            weatherData = inputParser.ParseInput(inputWeather);

            TryParseInput(inputWeather, inputParser);

            weatherPublisher.NotifyBots(weatherData);
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

    private static void TryParseInput(string inputWeather, IParsingInput parser)
    {
        try
        {
            parser.ParseInput(inputWeather);
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