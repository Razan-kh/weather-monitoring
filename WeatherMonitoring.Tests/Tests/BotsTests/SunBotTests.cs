using Xunit;
using FluentAssertions;
using Moq;
using System;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.Models;

public class SunBotTests
{
    [Fact]
    public void Notify_WhenTempratureAboveThreshold_ShouldCallActivate()
    {
        // Arrange
        bool activated = false;
        void FakeOutput(string msg) => activated = true;
        var config = new TemperatureConfiguration(30, "Sun!", true);
        var bot = new SunBot(config, FakeOutput);
        var weatherData = new WeatherData { Location = "City", Temperature = 35, Humidity = 60 };

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

        var config = new TemperatureConfiguration(70, "Wow, it's a scorcher out there!", true);
        var bot = new SunBot(config, FakeOutput);

        // Act
        bot.Activate();

        // Assert
        capturedMessage.Should().Be("Wow, it's a scorcher out there!");
    }
}