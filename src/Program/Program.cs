using WeatherMonitoringStation.Library;
using WeatherMonitoringStation.Library.Displays.Observers;
using WeatherMonitoringStation.Library.Factories;

namespace WeatherMonitoringStation.Program;

class Program
{
    static void Main()
    {
        var data = WeatherData.Instance;

        var statisticData = WeatherStation.GetDisplay(DisplayType.Statistics);
        var forecastData = WeatherStation.GetDisplay(DisplayType.Forcast);
        var conditionData = WeatherStation.GetDisplay(DisplayType.CurrentConditions);

        data.Subscribe(statisticData);
        data.Subscribe(forecastData);
        data.Subscribe(conditionData);

        data.GenerateNewData();

        data.Unsubscribe(statisticData);
        data.Unsubscribe(forecastData);
        data.Unsubscribe(conditionData);

        var conditionAndStatistic = new CurrentConditionsDisplay(statisticData);

        data.Subscribe(conditionAndStatistic);

        data.GenerateNewData();

        data.Unsubscribe(conditionAndStatistic);

        var conditionAndForecast = new CurrentConditionsDisplay(forecastData);

        data.Subscribe(conditionAndForecast);

        data.GenerateNewData();

        data.Unsubscribe(conditionAndForecast);
    }
}
