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

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Tassk> tassks = new List<Tassk>();
            tassks.Add(new Tassk("Grocery", "Pick up grocery", "2"));
            tassks.Add(new Tassk("Laundry", "Do my laundry", "1"));
            tassks.Add(new Tassk("Email", "Check mail and reply on urgent", "3"));
            this.DataContext = tassks;

        }
    }

    public class Tassk
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public Tassk(string name, string desc, string prior)
        {
            this.TaskName = name;
            this.Description = desc;
            this.Priority = prior;
        }
    }
}
