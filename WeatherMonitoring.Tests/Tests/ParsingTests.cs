using Xunit;
using FluentAssertions;
using WeatherMonitoring.Parsers;
using WeatherMonitoring.Parsers.Exceptions;

public class ParserTests
{
    private readonly JsonParser _jsonParser = new();
    private readonly XMLParser _xmlParser = new();

    [Fact]
    public void TryParse_ValidJson_ReturnsTrueAndData()
    {
        // Arrange
        var input = @"{""Location"": ""Nablus"", ""Temperature"": 32, ""Humidity"": 40}";
        // Act
        var data = _jsonParser.Parse(input);

        // Assert
        data.Should().NotBeNull();
        data!.Location.Should().Be("Nablus");
        data.Temperature.Should().Be(32);
        data.Humidity.Should().Be(40);
    }

    [Theory]
    [InlineData("")]
    [InlineData("not json")]
    [InlineData(@"{ ""Location"": ""Nablus"" }")] // missing fields
    public void TryParse_InvalidJson_ReturnsFalse(string input)
    {
        // Act
        Action act = () => _jsonParser.Parse(input);

        // Assert
        act.Should().Throw<JsonParsingException>()
        .WithMessage("Failed to parse JSON input.*");
    }

    [Fact]
    public void TryParse_ValidXml_ReturnsTrueAndData()
    {
        var input = @"<WeatherData><Location>Nablus</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";

        var data = _xmlParser.Parse(input);

        data!.Location.Should().Be("Nablus");
        data.Temperature.Should().Be(32);
        data.Humidity.Should().Be(40);
    }
}