namespace WeatherMonitoring.Parsers.Exceptions;

public abstract class ParsingException : Exception
{
    public ParsingException(string message) : base(message) { }

    protected ParsingException(string message, Exception inner)
        : base(message, inner) { }
}