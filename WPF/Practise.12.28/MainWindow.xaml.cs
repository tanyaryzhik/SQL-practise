using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practise._12._28
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 1;

       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void On_MouseEnter(object sender, MouseEventArgs e)
        {
           Debug.WriteLine($"MouseEnter: source {e.Source} sender {sender}");
        }

        private void On_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"MouseDown: source {e.Source} sender {sender}");
        }

        private void On_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == this.chkbx)
                return;

            Debug.WriteLine($"Click: source {e.Source} sender {sender}");
            while (i < 4)
            {
                Button btn = new Button() { Content = $"Button {i}" };
                btn.Margin = new Thickness(10);
                myPanel.Children.Add(btn);
                btn.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnClickPresssed));
                i++;
            }
            i = 1;
        }

        private void OnClickPresssed(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.Source;
            btn.Background = Brushes.Green;
            e.Handled = true;
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
           if(this.chkbx.IsChecked == true)
            {
                this.ellipse.Fill = Brushes.Green;
            }
           else
            {
                this.ellipse.Fill = Brushes.White;
                this.ellipse.Stroke = Brushes.Green;
            }
            e.Handled = true;
        }
    }

    public class BrushColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
