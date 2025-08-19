namespace weather_monitoring.ParsingInput;

public class ParserFactory
{
    public static IParsingInput CreateParser(string input)
    {
        input = input.Trim();
        return input.StartsWith('{')
            ? new JsonParser()
            : input.StartsWith('<') ? new XMLParser() : throw new NotSupportedException("Unknown input format");
    }
}