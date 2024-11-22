using System.IO;
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

namespace WpfBuilderDesignPattern
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

        private void BuildGamingPC_Click(object sender, RoutedEventArgs e)
        {
            var director = new Director(new GamingPCBuilder());
            var pc = director.BuildPC();
            PCInfo.Text = pc.GetSpecifications();
        }

        private void BuildOfficePC_Click(object sender, RoutedEventArgs e)
        {
            var director = new Director(new OfficePCBuilder());
            var pc = director.BuildPC();
            PCInfo.Text = pc.GetSpecifications();
        }
    }
}