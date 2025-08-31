using Xunit;
using FluentAssertions;
using System;
using WeatherMonitoring.Parsers;

public class ParserFactoryTests
{
    [Fact]
    public void CreateParser_InputTypeJson_ReturnsJsonParser()
    {
        // Arrange
        var inputType = InputType.Json;

        // Act
        var parser = ParserFactory.CreateParser(inputType);

        // Assert
        parser.Should().BeOfType<JsonParser>();
    }

    [Fact]
    public void CreateParser_InputTypeXml_ReturnsXmlParser()
    {
        // Arrange
        var inputType = InputType.XML;

        // Act
        var parser = ParserFactory.CreateParser(inputType);

        // Assert
        parser.Should().BeOfType<XMLParser>();
    }

    [Fact]
    public void CreateParser_UnsupportedInputType_ThrowsNotSupportedException()
    {
        // Arrange
        InputType unsupportedInput = (InputType)999;

        // Act
        Action act = () => ParserFactory.CreateParser(unsupportedInput);

        // Assert
        act.Should().Throw<NotSupportedException>()
           .WithMessage("Unknown parser type");
    }
}