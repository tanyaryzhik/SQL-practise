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

namespace Task7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { ID = 1, Department = "GIS", HiredDate = "2008-02-25", Name = "Alan Smith", IsManager = true });
            employees.Add(new Employee { ID = 2, Department = "Marketing", HiredDate = "2010-12-30", Name = "Alice Watts", IsManager = false });
            this.DataContext = employees;
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string HiredDate { get; set; }
            public bool IsManager { get; set; }

        }
    }
}
