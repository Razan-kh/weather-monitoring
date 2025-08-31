using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using WeatherMonitoring;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.Models;

public class WeatherPublisherTests
{
    [Fact]
    public void SubscribeBot_ShouldAddBot()
    {
        // Arrange
        var publisher = new WeatherPublisher();
        var mockBot = new Mock<IWeatherBot>();
        var weatherData = new WeatherData { Location = "City", Temperature = 25, Humidity = 50 };

        // Act
        publisher.SubscribeBot(mockBot.Object);
        publisher.NotifyBots(weatherData);

        // Assert
        mockBot.Verify(b => b.Notify(weatherData), Times.Once);
    }

    [Fact]
    public void SubscribeBots_ShouldAddMultipleBots()
    {
        // Arrange
        var publisher = new WeatherPublisher();
        var bots = new List<Mock<IWeatherBot>> { new Mock<IWeatherBot>(), new Mock<IWeatherBot>() };
        var weatherData = new WeatherData { Location = "City", Temperature = 20, Humidity = 40 };

        // Act
        publisher.SubscribeBots(new List<IWeatherBot> { bots[0].Object, bots[1].Object });
        publisher.NotifyBots(weatherData);

        // Assert
        bots[0].Verify(b => b.Notify(weatherData), Times.Once);
        bots[1].Verify(b => b.Notify(weatherData), Times.Once);
    }
}