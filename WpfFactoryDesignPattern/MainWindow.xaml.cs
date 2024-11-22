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

namespace WpfFactoryDesignPattern
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

        private void CreateCircle_Click(object sender, RoutedEventArgs e)
        {
            var shape = ShapeFactory.GetShape("Circle");
            ShapeInfo.Text = shape.Draw();
        }

        private void CreateSquare_Click(object sender, RoutedEventArgs e)
        {
            var shape = ShapeFactory.GetShape("Square");
            ShapeInfo.Text = shape.Draw();
        }
    }

    public interface IShape
    {
        string Draw();
    }

    public class Circle : IShape
    {
        public string Draw() => "Drawing a Circle";
    }

    public class Square : IShape
    {
        public string Draw() => "Drawing a Square";
    }

    public static class ShapeFactory
    {
        public static IShape GetShape(string shapeType)
        {
            return shapeType switch
            {
                "Circle" => new Circle(),
                "Square" => new Square(),
                _ => throw new ArgumentException("Invalid shape type")
            };
        }
    }
}