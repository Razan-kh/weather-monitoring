namespace WeatherMonitoring.Parsers;

public interface IParsingInput
{
    WeatherData ParseInput(string input);
}