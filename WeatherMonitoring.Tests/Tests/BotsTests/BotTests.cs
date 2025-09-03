using FluentAssertions;
using Moq;
using Xunit;
using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using Xunit;

namespace WeatherMonitoring.Tests.Tests.BotTests;

public class BotTests
{
    [Theory]
    [ClassData(typeof(BotTestData))]
    public void Notify_WhenConditionMet_ShouldCallActivate(Type botType, object botConfig, WeatherData weatherData, string expectedMessage)
    {
        // Arrange
        bool activated = false;
        void FakeOutput(string msg) => activated = true;

        // Create bot instance with FakeOutput
        var bot = (IWeatherBot)Activator.CreateInstance(botType, botConfig, (Action<string>)FakeOutput)!;

        // Act
        bot.Notify(weatherData);

        // Assert
        activated.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(BotTestData))]
    public void Activate_WhenCalled_ShouldPrintMessage(Type botType, object botConfig, WeatherData _, string expectedMessage)
    {
        // Arrange
        string? capturedMessage = null;
        void FakeOutput(string msg) => capturedMessage = msg;

        // Create bot instance with FakeOutput
        var bot = (IWeatherBot)Activator.CreateInstance(botType, botConfig, (Action<string>)FakeOutput)!;

        // Act
        bot.Activate();

        // Assert
        capturedMessage.Should().Be(expectedMessage);
    }
}