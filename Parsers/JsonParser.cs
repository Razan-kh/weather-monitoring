using System.Text.Json;

using WeatherMonitoring.Parsers.Exceptions;

namespace WeatherMonitoring.Parsers;

public class JsonParser : IParser
{
    public WeatherData Parse(string input)
    {
        try
        {
            var result = JsonSerializer.Deserialize<WeatherData>(input);
            return result is null ? throw new JsonParsingException("Deserialized object is null.") : result;
        }
        catch (JsonException exception)
        {
            throw new JsonParsingException("Failed to parse JSON input.", exception);
        }
        catch (NotSupportedException exception)
        {
            throw new JsonParsingException("The JSON input type is not supported.", exception);
        }
    }
}