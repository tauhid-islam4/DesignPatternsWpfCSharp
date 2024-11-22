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

namespace WpfDecoratorDesignPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBeverage beverage;

        public MainWindow()
        {
            InitializeComponent();
            beverage = new Coffee();
            BeverageInfo.Text = beverage.GetDescription() + " $" + beverage.Cost();
        }

        private void AddMilk_Click(object sender, RoutedEventArgs e)
        {
            beverage = new Milk(beverage);
            BeverageInfo.Text = beverage.GetDescription() + " $" + beverage.Cost();
        }

        private void AddSugar_Click(object sender, RoutedEventArgs e)
        {
            beverage = new Sugar(beverage);
            BeverageInfo.Text = beverage.GetDescription() + " $" + beverage.Cost();
        }
    }

    public interface IBeverage
    {
        string GetDescription();
        double Cost();
    }

    public class Coffee : IBeverage
    {
        public string GetDescription() => "Coffee";
        public double Cost() => 5.0;
    }

    public class Milk : IBeverage
    {
        private readonly IBeverage beverage;

        public Milk(IBeverage beverage)
        {
            this.beverage = beverage;
        }

        public string GetDescription() => beverage.GetDescription() + ", Milk";
        public double Cost() => beverage.Cost() + 1.5;
    }

    public class Sugar : IBeverage
    {
        private readonly IBeverage beverage;

        public Sugar(IBeverage beverage)
        {
            this.beverage = beverage;
        }

        public string GetDescription() => beverage.GetDescription() + ", Sugar";
        public double Cost() => beverage.Cost() + 0.5;
    }
}