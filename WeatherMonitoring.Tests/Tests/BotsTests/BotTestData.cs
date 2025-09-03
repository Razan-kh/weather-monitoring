using System.Collections;
using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.WeatherBots.BotConfigurations;
using System.Collections;
using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots;
using WeatherMonitoring.WeatherBots.BotConfigurations;

namespace WeatherMonitoring.Tests.Tests.BotTests;

public class BotTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // RainBot
        yield return new object[]
        {
            typeof(RainBot),
            new HumidityConfiguration(50, "Rain!", true),
            new WeatherData { Location = "City", Temperature = 25, Humidity = 60 },
            "Rain!"
        };

        // SnowBot
        yield return new object[]
        {
            typeof(SnowBot),
            new TemperatureConfiguration(3, "Snow!", true),
            new WeatherData { Location = "City", Temperature = 0, Humidity = 60 },
            "Snow!"
        };

        // SunBot
        yield return new object[]
        {
            typeof(SunBot),
            new TemperatureConfiguration(30, "Sun!", true),
            new WeatherData { Location = "City", Temperature = 35, Humidity = 60 },
            "Sun!"
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}