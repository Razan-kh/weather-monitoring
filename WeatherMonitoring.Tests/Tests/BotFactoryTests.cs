using FluentAssertions;
using WeatherMonitoring.Enums;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using WeatherMonitoring.Models;
using FluentAssertions.Execution;

namespace WeatherMonitoring.Tests.Tests;

public class BotFactoryTests
{
    [Fact]
    public void CreateBots_ShouldReturnBots_WhenTheyAreEnabled()
    {
        // Arrange
        var configs = new Dictionary<BotType, BotConfiguration>
        {
            { BotType.RainBot, new HumidityConfiguration (70, "Rain!", true) },
            { BotType.SunBot,  new TemperatureConfiguration (30, "Sun!", false) },
        };

        // Act
        var bots = BotFactory.CreateBots(configs);

        // Assert
        using (new AssertionScope())
        {
            bots.Should().HaveCount(1);
            bots[0].Should().BeOfType<RainBot>();
        }
    }

    public static IEnumerable<object[]> BotTestData =>
        new List<object[]>
        {
            new object[] { BotType.RainBot, new HumidityConfiguration(70, "Rain!", true), typeof(RainBot) },
            new object[] { BotType.SunBot, new TemperatureConfiguration(30, "Sun!", true), typeof(SunBot) }
        };

    [Theory]
    [MemberData(nameof(BotTestData))]
    public void CreateBot_ValidConfig_ReturnsCorrectType(BotType botType, BotConfiguration config, Type expectedType)
    {
        // Act
        var bot = BotFactory.CreateBot(botType, config);

        // Assert
        bot.Should().BeOfType(expectedType);
    }

    [Fact]
    public void CreateBot_ValidConfig_ReturnsCorrectBot()
    {
        var temperatureConfiguration = new TemperatureConfiguration(30, "SunBot", true);
        SunBot actual = new SunBot(temperatureConfiguration);
        var sunBot = actual.As<SunBot>();

        // Act
        var expected = BotFactory.CreateBot(BotType.SunBot, temperatureConfiguration);

        // Assert
        using (new AssertionScope())
        {
            actual.Should().BeOfType<SunBot>();
            sunBot.Message.Should().Be(expected.Message);
            sunBot.Enabled.Should().Be(expected.Enabled);
        }
    }
}