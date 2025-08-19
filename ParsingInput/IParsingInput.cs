namespace weather_monitoring.ParsingInput;

public interface IParsingInput
{
    WeatherData ParseInput(string input);
}