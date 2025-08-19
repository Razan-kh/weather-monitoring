using weather_monitoring.IWeatherBots;
using weather_monitoring.ParsingInput;

namespace weather_monitoring;

public class WeatherPublisher
{
    private readonly List<IWeatherBot> _bots = [];
    private readonly IParsingInput _parsingInput;

    public WeatherPublisher(IParsingInput parsingInput)
    {
        _parsingInput = parsingInput;
    }

    public void SubscribeBot(IWeatherBot bot) => _bots.Add(bot);

    public void UnsubscribeBot
    (IWeatherBot bot) => _bots.Remove(bot);

    public void ParseInput(string input)
    {
        var weatherData = _parsingInput.ParseInput(input);
        NotifyBots(weatherData);
    }

    private void NotifyBots(WeatherData weatherData)
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