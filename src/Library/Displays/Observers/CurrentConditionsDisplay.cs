using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library.Displays.Observers
{
    /// <summary>
    /// The 'CurrentConditionsDisplay' class implements the 'IDisplay' interface.
    /// It is responsible for displaying the current weather conditions.
    /// </summary>
    public class CurrentConditionsDisplay : IDisplay
    {
        private IDisplay? _display;

        /// <summary>
        /// Default constructor for the 'CurrentConditionsDisplay' class.
        /// </summary>
        public CurrentConditionsDisplay() { }

        /// <summary>
        /// Overloaded constructor for the 'CurrentConditionsDisplay' class.
        /// Takes an 'IDisplay' object as a parameter.
        /// </summary>
        /// <param name="display">An 'IDisplay' object.</param>
        public CurrentConditionsDisplay(IDisplay display)
        {
            _display = display;
        }

        /// <summary>
        /// The 'Display' method takes a 'WeatherData' object as a parameter.
        /// It displays the current weather conditions and temperature in a specific format.
        /// </summary>
        /// <param name="weatherData">An object of 'WeatherData' which contains the weather data to be displayed.</param>
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
}
