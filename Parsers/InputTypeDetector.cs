namespace WeatherMonitoring.Parsers;

public static class InputTypeDetector
{
    public static InputType Detect(string input)
    {
        input = input.Trim();
        return input.StartsWith('{')
            ? InputType.Json
            : input.StartsWith('<') ? InputType.XML : throw new NotSupportedException("Unknown input format");
    }
}