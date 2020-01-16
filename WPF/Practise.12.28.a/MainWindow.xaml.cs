using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Practise._12._28.a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Emloyee> Employees { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.Employees = new ObservableCollection<Emloyee>();
            Employees.Add(new Emloyee { ID = 1, Name = "Alex Mann", Department = "GIS", HireDate = "2019-12-05", IsManager = true });
            Employees.Add(new Emloyee { ID = 2, Name = "Mary King", Department = "Marketing", HireDate = "2005-12-24", IsManager = false });
            Emloyee.counter = 3;
            this.employeesGrid.ItemsSource = Employees;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Employees.Add(new Emloyee { ID = Emloyee.counter++ });
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Employees.Remove(this.employeesGrid.SelectedItem as Emloyee);
        }

        private void ShowCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new EmployeeData { DataContext = this.employeesGrid.SelectedItem as Emloyee }.Show();
        }

        private void Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
                if (this.employeesGrid.SelectedItem != null)
                    e.CanExecute = true;
                else
                    e.CanExecute = false;
        }
    }

    public class Emloyee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string HireDate { get; set; }

        public bool IsManager { get; set; }

        public static int counter = 0;
    }

    public static class MyCommands
    {
        public static RoutedCommand Show { get; set; }

        static MyCommands()
        {
            MyCommands.Show = new RoutedCommand(nameof(Show), typeof(MainWindow));
        }
    }
}
