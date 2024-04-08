using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers
{
    /// <summary>
    /// The 'StatisticsDisplay' class implements the 'IDisplay' interface.
    /// It is responsible for displaying weather statistics.
    /// </summary>
    public class StatisticsDisplay : IDisplay
    {
        /// <summary>
        /// The 'Display' method takes a 'WeatherData' object as a parameter.
        /// It displays the current temperature, maximum and minimum temperatures,
        /// wind speed, and precipitation percentage.
        /// </summary>
        /// <param name="weatherData">An object of 'WeatherData' which contains the weather data to be displayed.</param>
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
}
