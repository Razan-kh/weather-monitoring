namespace weather_monitoring.IWeatherBots;

public interface IWeatherBot
{
    bool Enabled { get; }
    string Message { get; }
    void Notify(WeatherData data);
    void Activate();
}