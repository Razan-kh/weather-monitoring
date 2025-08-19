using System.Text.Json;

namespace weather_monitoring.ParsingInput;

public class JsonParser : IParsingInput
{
    public WeatherData ParseInput(string input) => JsonSerializer.Deserialize<WeatherData>(input);
}