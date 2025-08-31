namespace WeatherMonitoring.Parsers.Exceptions;

public class JsonParsingException : ParsingException
{
    public JsonParsingException(string message) : base(message) { }

    public JsonParsingException(string message, Exception innerException)
        : base(message, innerException) { }
}