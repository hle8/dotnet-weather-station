using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library;

public class WeatherData
{
    private static readonly Lazy<WeatherData> _instance = new(() => new WeatherData());

    private readonly IList<IDisplay> observers = [];

    public static WeatherData Instance => _instance.Value;

    public double MaxTemp { get; set; }
    public double MinTemp { get; set; }
    public double CurrentTemp { get; set; }
    public double Humidity { get; set; }
    public double Precipitation { get; set; }
    public double Wind { get; set; }
    public double WindSpeed { get; set; }
    public double[] ForecastTemp { get; set; } = new double[5];

    public void Subscribe(IDisplay observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void Unsubscribe(IDisplay observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Display(this);
        }
    }

    public void GenerateNewData()
    {
        var rand = new Random();

        MaxTemp = rand.NextDouble() + rand.Next(-60, 40);
        MinTemp = rand.NextDouble() + rand.Next(-60, (int)Math.Round(MaxTemp));
        CurrentTemp =
            rand.NextDouble() + rand.Next((int)Math.Round(MinTemp), (int)Math.Round(MaxTemp));
        Humidity = rand.NextDouble() * 100;
        Precipitation = rand.NextDouble() * 100;
        Wind = rand.Next(100);
        for (int i = 0; i < ForecastTemp.Length; i++)
        {
            ForecastTemp[i] = rand.NextDouble() + rand.Next(-60, 40);
        }

        Notify();
    }
}
