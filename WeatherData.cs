namespace weather_monitoring;

public class WeatherData
{
    public required string Location { get; set; }
    public required double Temperature { get; set; }
    public required double Humidity { get; set; }
}