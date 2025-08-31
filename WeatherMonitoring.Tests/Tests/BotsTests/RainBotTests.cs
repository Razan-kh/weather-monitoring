using Xunit;
using FluentAssertions;
using Moq;
using System;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.Models;

public class RainBotTests
{
    [Fact]
    public void Notify_WhenHumidityAboveThreshold_ShouldCallActivate()
    {
        // Arrange
        bool activated = false;
        void FakeOutput(string msg) => activated = true;
        var config = new HumidityConfiguration(50, "Rain!", true);
        var bot = new RainBot(config, FakeOutput);
        var weatherData = new WeatherData { Location = "City", Temperature = 25, Humidity = 60 };

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

        var config = new HumidityConfiguration(70, "It looks like it's about to pour down!", true);
        var bot = new RainBot(config, FakeOutput);

        // Act
        bot.Activate();

        // Assert
        capturedMessage.Should().Be("It looks like it's about to pour down!");
    }
}