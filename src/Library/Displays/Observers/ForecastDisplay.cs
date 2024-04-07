using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers;

public class ForecastDisplay : IDisplay
{
    public void Display(WeatherData weatherData)
    {
        Console.WriteLine($"+-----------------------");
        Console.WriteLine($"| Forecast (next 5 days)");
        Console.WriteLine($"+-----------------------");

        Console.Write("|");
        foreach (var item in weatherData.ForecastTemp)
        {
            Console.Write($" {Math.Round(item)}\u00B0C |");
        }

        Console.WriteLine("");
    }
}
