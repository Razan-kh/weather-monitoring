using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using WeatherMonitoring;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Tests.Tests;

public class WeatherPublisherTests
{
    [Fact]
    public void SubscribeBot_WhenSingleBotSubscribed_ShouldContainThatBot()
    {
        // Arrange
        var publisher = new WeatherPublisher();
        var mockBot = new Mock<IWeatherBot>();

        // Act
        publisher.SubscribeBot(mockBot.Object);

        // Assert
        var subscribedBots = publisher.GetSubscribedBots();
        subscribedBots.Should().ContainSingle().Which.Should().Be(mockBot.Object);
    }

    [Fact]
    public void SubscribeBots_WhenMultipleBotsSubscribed_ShouldContainAllBots()
    {
        // Arrange
        var publisher = new WeatherPublisher();
        var mockBot1 = new Mock<IWeatherBot>();
        var mockBot2 = new Mock<IWeatherBot>();
        var mockBot3 = new Mock<IWeatherBot>();

        var bots = new List<IWeatherBot> { mockBot1.Object, mockBot2.Object, mockBot3.Object };

        // Act
        publisher.SubscribeBots(bots);

        // Assert
        var subscribedBots = publisher.GetSubscribedBots();
        subscribedBots.Should().HaveCount(3).And.Contain(bots);
    }
}