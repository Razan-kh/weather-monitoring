
using WeatherMonitoring.Models;
using WeatherMonitoring.WeatherBots;

namespace WeatherMonitoring;

public class WeatherPublisher
{
    private readonly List<IWeatherBot> _bots = [];

    public void SubscribeBot(IWeatherBot bot) => _bots.Add(bot);

    public void UnsubscribeBot
    (IWeatherBot bot) => _bots.Remove(bot);

    public void NotifyBots(WeatherData weatherData)
    {
        foreach (var bot in _bots)
        {
            bot.Notify(weatherData);
        }
    }

    public void SubscribeBots(List<IWeatherBot> bots)
    {
        foreach (var bot in bots)
        {
            SubscribeBot(bot);
        }
    }
}