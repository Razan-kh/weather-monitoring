using WeatherMonitoring.Models;

namespace WeatherMonitoring.Parsers;

public interface IParser
{
    WeatherData Parse(string input);
}