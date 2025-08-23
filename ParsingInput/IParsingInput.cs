namespace WeatherMonitoring.ParsingInput;

public interface IParsingInput
{
    WeatherData ParseInput(string input);
}