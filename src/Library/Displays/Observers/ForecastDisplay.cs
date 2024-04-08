using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers
{
    /// <summary>
    /// The 'ForecastDisplay' class implements the 'IDisplay' interface.
    /// It is responsible for displaying the weather forecast for the next 5 days.
    /// </summary>
    public class ForecastDisplay : IDisplay
    {
        /// <summary>
        /// The 'Display' method takes a 'WeatherData' object as a parameter.
        /// It displays the forecast temperatures for the next 5 days.
        /// </summary>
        /// <param name="weatherData">An object of 'WeatherData' which contains the weather data to be displayed.</param>
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
}
