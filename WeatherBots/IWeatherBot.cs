namespace WeatherMonitoring.WeatherBots;

public interface IWeatherBot
{
    bool Enabled { get; }
    string Message { get; }
    void Notify(WeatherData data);
    void Activate();
}