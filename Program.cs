﻿namespace WeatherMonitoring.WeatherBots;

public class Program
{
    private const string ConfigFileName = "Configuration.json";

    public static void Main()
    {
        var configs = ConfigLoader.Load(ConfigFileName);
        var bots = BotFactory.CreateBots(configs);
    }
}