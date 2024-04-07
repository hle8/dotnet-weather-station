using WeatherMonitoringStation.Library.Displays.Interfaces;
using WeatherMonitoringStation.Library.Displays.Observers;

namespace WeatherMonitoringStation.Library.Factories;

public enum DisplayType
{
    CurrentConditions,
    Statistics,
    Forcast
}

public class WeatherStation
{
    public static IDisplay GetDisplay(DisplayType displayType)
    {
        switch (displayType)
        {
            case DisplayType.CurrentConditions:
                return new CurrentConditionsDisplay();
            case DisplayType.Statistics:
                return new StatisticsDisplay();
            case DisplayType.Forcast:
                return new ForecastDisplay();
            default:
                throw new ArgumentException("Invalid display type!");
        }
    }
}
