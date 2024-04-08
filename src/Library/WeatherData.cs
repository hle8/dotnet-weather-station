using WeatherMonitoringStation.Library.Displays.Interfaces;

namespace WeatherMonitoringStation.Library
{
    /// <summary>
    /// The 'WeatherData' class is a singleton that holds weather data and manages its observers.
    /// </summary>
    public class WeatherData
    {
        // Singleton instance of the WeatherData class
        private static readonly Lazy<WeatherData> _instance = new(() => new WeatherData());

        // List of observers subscribed to the WeatherData
        private readonly IList<IDisplay> observers = [];

        // Property to get the singleton instance
        public static WeatherData Instance => _instance.Value;

        // Properties to hold the weather data
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public double CurrentTemp { get; set; }
        public double Humidity { get; set; }
        public double Precipitation { get; set; }
        public double Wind { get; set; }
        public double WindSpeed { get; set; }
        public double[] ForecastTemp { get; set; } = new double[5];

        /// <summary>
        /// Subscribes an observer to the WeatherData.
        /// </summary>
        /// <param name="observer">The observer to be subscribed.</param>
        public void Subscribe(IDisplay observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        /// <summary>
        /// Unsubscribes an observer from the WeatherData.
        /// </summary>
        /// <param name="observer">The observer to be unsubscribed.</param>
        public void Unsubscribe(IDisplay observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all subscribed observers to display the current weather data.
        /// </summary>
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Display(this);
            }
        }

        /// <summary>
        /// Generates new random weather data and notifies the observers.
        /// </summary>
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
}
