namespace WeatherMonitoring.Parsers;

public static class InputTypeDetector
{
    public static InputType Detect(string input)
    {
        input = input.Trim();
        return input switch
        {
            string s when s.StartsWith('{') => InputType.Json,
            string s when s.StartsWith('<') => InputType.XML,
            _ => throw new NotSupportedException("Unknown input format")
        };
    }
}