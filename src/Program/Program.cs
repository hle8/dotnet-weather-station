using WeatherMonitoringStation.Library;
using WeatherMonitoringStation.Library.Displays.Observers;
using WeatherMonitoringStation.Library.Factories;

namespace WeatherMonitoringStation.Program
{
    class Program
    {
        static void Main()
        {
            // Get the singleton instance of WeatherData
            var data = WeatherData.Instance;

            // Create display objects for statistics, forecast, and current conditions
            var statisticData = WeatherStation.GetDisplay(DisplayType.Statistics);
            var forecastData = WeatherStation.GetDisplay(DisplayType.Forcast);
            var conditionData = WeatherStation.GetDisplay(DisplayType.CurrentConditions);

            // Subscribe the display objects to the WeatherData instance
            data.Subscribe(statisticData);
            data.Subscribe(forecastData);
            data.Subscribe(conditionData);

            // Generate new weather data
            data.GenerateNewData();

            // Unsubscribe the display objects from the WeatherData instance
            data.Unsubscribe(statisticData);
            data.Unsubscribe(forecastData);
            data.Unsubscribe(conditionData);

            // Create a CurrentConditionsDisplay object that wraps the statisticData display
            var conditionAndStatistic = new CurrentConditionsDisplay(statisticData);

            // Subscribe the new display object to the WeatherData instance
            data.Subscribe(conditionAndStatistic);

            // Generate new weather data
            data.GenerateNewData();

            // Unsubscribe the new display object from the WeatherData instance
            data.Unsubscribe(conditionAndStatistic);

            // Create a CurrentConditionsDisplay object that wraps the forecastData display
            var conditionAndForecast = new CurrentConditionsDisplay(forecastData);

            // Subscribe the new display object to the WeatherData instance
            data.Subscribe(conditionAndForecast);

            // Generate new weather data
            data.GenerateNewData();

            // Unsubscribe the new display object from the WeatherData instance
            data.Unsubscribe(conditionAndForecast);
        }
    }
}
