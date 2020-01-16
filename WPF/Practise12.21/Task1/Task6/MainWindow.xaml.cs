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

namespace Task6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Emloyee> emloyees = new List<Emloyee>();
            emloyees.Add(new Emloyee { ID = 1, Name = "Alex Kotoff", Department = "Gis", HireDate = new DateTime(2008, 3, 1, 7, 0, 0), IsManager = true });
            this.DataContext = emloyees;
        }
    }

    public class Emloyee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsManager { get; set; }
    }
}
