using Xunit;
using FluentAssertions;
using WeatherMonitoring.Parsers;
using WeatherMonitoring.Parsers.Exceptions;
using WeatherMonitoring.Models;
using FluentAssertions.Execution;

namespace WeatherMonitoring.Tests.Tests;

public class ParserTests
{
    private readonly JsonParser _jsonParser = new();
    private readonly XMLParser _xmlParser = new();

    [Fact]
    public void TryParse_ValidJson_ReturnsTrueAndData()
    {
        // Arrange
        var input = @"{""Location"": ""Nablus"", ""Temperature"": 32, ""Humidity"": 40}";
        var expected = new WeatherData { Humidity = 40, Temperature = 32, Location = "Nablus" };

        // Act
        var result = _jsonParser.Parse(input);

        // Assert
        result?.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("")]
    [InlineData("not json")]
    [InlineData(@"{ ""Location"": ""Nablus"" }")] // missing fields
    public void TryParse_InvalidJson_ThrowsException(string input)
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
        // Arrange
        var input = @"<WeatherData><Location>Nablus</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
        var expected = new WeatherData { Humidity = 40, Temperature = 32, Location = "Nablus" };
        
        // Act
        var result = _xmlParser.Parse(input);

        // Assert
        result?.Should().BeEquivalentTo(expected);
    }
}