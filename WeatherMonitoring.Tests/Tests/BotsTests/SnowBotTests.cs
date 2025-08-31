using Xunit;
using FluentAssertions;
using Moq;
using System;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.Models;

public class SnowBotTests
{
    [Fact]
    public void Notify_WhenTempratureBelowThreshold_ShouldCallActivate()
    {
        // Arrange
        bool activated = false;
        void FakeOutput(string msg) => activated = true;
        var config = new TemperatureConfiguration(3, "Sun!", true);
        var bot = new SnowBot(config, FakeOutput);
        var weatherData = new WeatherData { Location = "City", Temperature =0, Humidity = 60 };

        // Act
        bot.Notify(weatherData);

        // Assert
        activated.Should().BeTrue();
    }

    [Fact]
    public void Activate_ShouldCallOutputWithMessage()
    {
        // Arrange
        string? capturedMessage = null;
        void FakeOutput(string msg) => capturedMessage = msg;

        var config = new TemperatureConfiguration(5, "Brrr, it's getting chilly!", true);
        var bot = new SnowBot(config, FakeOutput);

        // Act
        bot.Activate();

        // Assert
        capturedMessage.Should().Be("Brrr, it's getting chilly!");
    }
}