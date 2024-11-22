using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfObserverDesignPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherStation weatherStation;

        public MainWindow()
        {
            InitializeComponent();

            // Create WeatherStation instance
            weatherStation = new WeatherStation();

            // Create WeatherDisplay observer and pass the update action
            var observer = new WeatherDisplay(data =>
            {
                WeatherDisplay.Text = data;
            });

            // Attach the observer to the weather station
            weatherStation.Attach(observer);
        }

        private void UpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            // Update the weather data
            weatherStation.SetWeather($"Temperature: {new Random().Next(20, 35)}°C");
        }
    }

    public interface IObserver
    {
        void Update(string data);
    }

    public class WeatherDisplay : IObserver
    {
        private readonly Action<string> updateAction;

        // Constructor accepting an Action<string> as the update action
        public WeatherDisplay(Action<string> updateAction)
        {
            this.updateAction = updateAction;
        }

        // Invokes the update action when notified
        public void Update(string data)
        {
            updateAction(data);
        }
    }

    public class WeatherStation
    {
        private List<IObserver> observers = new List<IObserver>();
        private string weather;

        // Attaches an observer to the station
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        // Notifies all attached observers
        public void Notify()
        {
            observers.ForEach(o => o.Update(weather));
        }

        // Updates the weather and notifies observers
        public void SetWeather(string newWeather)
        {
            weather = newWeather;
            Notify();
        }
    }
}