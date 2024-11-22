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

namespace WpfSingletonDesignPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogMessage_Click(object sender, RoutedEventArgs e)
        {
            Logger.Instance.Log("Message logged at " + DateTime.Now);
            LogOutput.Text = Logger.Instance.GetLog();
        }
    }

    public sealed class Logger
    {
        private static readonly Lazy<Logger> instance = new(() => new Logger());
        private string log = "";

        private Logger() { }

        public static Logger Instance => instance.Value;

        public void Log(string message)
        {
            log += message + Environment.NewLine;
        }

        public string GetLog() => log;
    }
}