namespace WeatherMonitoring.Parsers.Exceptions;

public class XmlParsingException : ParsingException
{
    public XmlParsingException(string message) : base(message) { }

    public XmlParsingException(string message, Exception innerException)
        : base(message, innerException) { }
}