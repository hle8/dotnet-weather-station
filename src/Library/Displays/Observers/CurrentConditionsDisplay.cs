using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers;

public class CurrentConditionsDisplay : IDisplay
{
    private IDisplay? _display;

    public CurrentConditionsDisplay() { }

    public CurrentConditionsDisplay(IDisplay display)
    {
        _display = display;
    }

    public void Display(WeatherData weatherData)
    {
        if (_display != null)
        {
            Console.WriteLine($"+-----------------------------");
            Console.WriteLine($"| Last updated: {DateTime.Now}");
            Console.WriteLine($"+-----------------------------");
            _display.Display(weatherData);
        }

        string currentTempDisplay = weatherData.CurrentTemp switch
        {
            < -45 => "Unearthly Cold",
            >= -45 and < -30 => "Extreme Cold",
            >= -30 and < -15 => "Severe Cold",
            >= -15 and < 6 => "Cold",
            >= 6 and < 16 => "Moderate",
            >= 16 and < 31 => "Warm",
            >= 32 => "Hot",
            _ => "Invalid",
        };

        Console.WriteLine($"+-----------");
        Console.WriteLine($"| Conditions");
        Console.WriteLine($"+-----------");
        Console.WriteLine($"| Temp: {currentTempDisplay}");
    }
}
