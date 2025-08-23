using System.Xml.Serialization;

namespace WeatherMonitoring.ParsingInput;

public class XMLParser : IParsingInput
{
    public WeatherData ParseInput(string input)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));
        using var reader = new StringReader(input);
        return (WeatherData)serializer.Deserialize(reader);
    }
}