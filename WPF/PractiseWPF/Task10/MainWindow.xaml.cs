using System;
using System.Collections.Generic;
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

namespace Task10
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

        private void OnButtonClick(object sender, RoutedEventArgs e)
            { 
            if (theTextBox.Text == "0")
                theTextBox.Text = String.Empty;
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "Button9":
                      theTextBox.Text = theTextBox.Text + "7";
                      break;
                case "Button10":
                      theTextBox.Text = theTextBox.Text + "8";
                      break;
                case "Button11":
                      theTextBox.Text = theTextBox.Text + "9";
                      break;
                case "Button13":
                      theTextBox.Text = theTextBox.Text + "4";
                      break;
                case "Button14":
                      theTextBox.Text = theTextBox.Text + "5";
                      break;
                case "Button15":
                      theTextBox.Text = theTextBox.Text + "6";
                      break;
                case "Button17":
                      theTextBox.Text = theTextBox.Text + "1";
                      break;
                case "Button18":
                      theTextBox.Text = theTextBox.Text + "2";
                      break;
                case "Button19":
                      theTextBox.Text = theTextBox.Text + "3";
                      break;
                case "Button22":
                      theTextBox.Text = theTextBox.Text + "0";
                      break;
                case "Button23":
                      theTextBox.Text = theTextBox.Text + ".";
                      break;
                 
            }
        }
    }
}
