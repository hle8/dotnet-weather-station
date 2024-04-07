using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers;

public class StatisticsDisplay : IDisplay
{
    public void Display(WeatherData weatherData)
    {
        Console.WriteLine($"+-----------");
        Console.WriteLine($"| Statistics");
        Console.WriteLine($"+-----------");
        Console.WriteLine(
            $"| Current temperature (\u00B0C): {Math.Round(weatherData.CurrentTemp, 2)}"
        );
        Console.WriteLine(
            $"| Max/Min temperature (\u00B0C): {Math.Round(weatherData.MaxTemp, 2)}/{Math.Round(weatherData.MinTemp, 2)}"
        );
        Console.WriteLine($"| Wind (mph): {weatherData.Wind}");
        Console.WriteLine($"| Precipitation (%): {Math.Round(weatherData.Precipitation)}");
    }
}
