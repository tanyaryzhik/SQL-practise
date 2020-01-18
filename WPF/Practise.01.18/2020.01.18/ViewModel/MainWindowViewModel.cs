using _2020._01._18.Commands;
using _2020._01._18.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020._01._18.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get; set; }
        public ICommand New { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Get { get; set; }

        public MainWindowViewModel()
        {
            this.Employees = new ObservableCollection<Employee>();
            this.New = new RelayCommand(NewCommandExecute);
            this.Delete = new RelayCommand(DeleteCommandExecute, DeleteCommandCanExecute);
            this.Get = new RelayCommand(GetCommandExecute, GetCommandCanExecute);
        }

        private bool GetCommandCanExecute(object obj)
        {
            return this.Employees == null;
        }

        private void GetCommandExecute(object obj)
        {
            var empCollection= new ObservableCollection<Employee>();
            Ge
        }

        private bool DeleteCommandCanExecute(object obj)
        {
            return this.SelectedEmployee != null;
        }

        private void DeleteCommandExecute(object obj)
        {
            this.Employees.Remove(this.SelectedEmployee);
        }

        private void NewCommandExecute(object obj)
        {
            this.Employees.Add(new Employee { ID = Employee.counter++ });
        }

        private void GetEmployees()
        {
            Employees.Add(new Employee { ID = 1, Name = "Alex Mann", Department = "GIS", HireDate = "2019-12-05", IsManager = true });
            Employees.Add(new Employee { ID = 2, Name = "Mary King", Department = "Marketing", HireDate = "2005-12-24", IsManager = false });
            Employee.counter = 3;
        }
    }
}

//private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
//{
//    this.Employees.Add(new Emloyee { ID = Emloyee.counter++ });
//}

//private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
//{
//    this.Employees.Remove(this.employeesGrid.SelectedItem as Emloyee);
//}

//private void ShowCommand_Executed(object sender, ExecutedRoutedEventArgs e)
//{
//    new EmployeeData { DataContext = this.employeesGrid.SelectedItem as Emloyee }.Show();
//}

//private void Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
//{
//    if (this.employeesGrid.SelectedItem != null)
//        e.CanExecute = true;
//    else
//        e.CanExecute = false;
//}
