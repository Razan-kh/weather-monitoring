using FluentAssertions;
using WeatherMonitoring.Enums;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.WeatherBots.BotConfigurations;

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
using (new AssertionScope)
{
        bots.Should().HaveCount(1);
        bots[0].Should().BeOfType<RainBot>();
}
    }

    [Fact]
    public void CreateBot_ReturnsCorrectType()
    {
        // Arrange
        var rainConfig = new HumidityConfiguration (70, "Rain!", true);
        var sunConfig  = new TemperatureConfiguration (30, "Sun!", true);
        
        // Act
        var rainBot = BotFactory.CreateBot(BotType.RainBot, rainConfig);
        var sunBot  = BotFactory.CreateBot(BotType.SunBot, sunConfig);

        // Assert
        rainBot.Should().BeOfType<RainBot>();
        sunBot.Should().BeOfType<SunBot>();
    }
}