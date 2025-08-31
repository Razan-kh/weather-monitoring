namespace WeatherMonitoring.Parsers;

public class ParserFactory
{
    public static IParser CreateParser(InputType input)
    {
        return input switch
        {
            InputType.Json => new JsonParser(),
            InputType.XML => new XMLParser(),
            _ => throw new NotSupportedException("Unknown parser type")
        };
    }
}