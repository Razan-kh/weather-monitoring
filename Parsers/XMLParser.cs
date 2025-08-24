using System.Xml;
using System.Xml.Serialization;
using WeatherMonitoring.Parsers.Exceptions;

namespace WeatherMonitoring.Parsers;

public class XMLParser : IParsingInput
{
    public WeatherData ParseInput(string input)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit, // Disable DTDs (avoid XXE)
                XmlResolver = null                      // Prevent external entity resolution
            };
            using var stringReader = new StringReader(input);
            using var xmlReader = XmlReader.Create(stringReader, settings);
            var result = serializer.Deserialize(xmlReader);
            return result is WeatherData weatherData
                ? weatherData
                : throw new XmlParsingException("Deserialized object is null or not of type WeatherData.");
        }
        catch (InvalidOperationException exception)
        {
            throw new XmlParsingException("Failed to parse XML input.", exception);
        }
    }
}