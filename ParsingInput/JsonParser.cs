using System.Text.Json;

namespace WeatherMonitoring.ParsingInput;

public class JsonParser : IParsingInput
{
    public WeatherData ParseInput(string input) => JsonSerializer.Deserialize<WeatherData>(input);
}