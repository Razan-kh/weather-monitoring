using System.Text.Json;
using WeatherMonitoring.Parsers.Exceptions;

namespace WeatherMonitoring.Parsers;

public class JsonParser : IParsingInput
{
    public WeatherData ParseInput(string input)
    {
        try
        {
            var result = JsonSerializer.Deserialize<WeatherData>(input);
            return result is null ? throw new JsonParsingException("Deserialized object is null.") : result;
        }
        catch (JsonException ex)
        {
            throw new JsonParsingException("Failed to parse JSON input.", ex);
        }
        catch (NotSupportedException ex)
        {
            throw new JsonParsingException("The JSON input type is not supported.", ex);
        }
    }
}