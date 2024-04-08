using WeatherMonitoringStation.Library.Displays.Interfaces;
using WeatherMonitoringStation.Library.Displays.Observers;

namespace WeatherMonitoringStation.Library.Factories
{
    /// <summary>
    /// The 'DisplayType' enumeration lists the types of displays available.
    /// </summary>
    public enum DisplayType
    {
        CurrentConditions,
        Statistics,
        Forcast
    }

    /// <summary>
    /// The 'WeatherStation' class is responsible for creating display objects.
    /// </summary>
    public class WeatherStation
    {
        /// <summary>
        /// The 'GetDisplay' method takes a 'DisplayType' enumeration as a parameter.
        /// It returns an 'IDisplay' object based on the 'DisplayType' parameter.
        /// </summary>
        /// <param name="displayType">An enumeration of 'DisplayType' which specifies the type of display to be created.</param>
        /// <returns>An 'IDisplay' object of the specified type.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid display type is provided.</exception>
        public static IDisplay GetDisplay(DisplayType displayType)
        {
            return displayType switch
            {
                DisplayType.CurrentConditions => new CurrentConditionsDisplay(),
                DisplayType.Statistics => new StatisticsDisplay(),
                DisplayType.Forcast => new ForecastDisplay(),
                _ => throw new ArgumentException("Invalid display type!"),
            };
        }
    }
}
