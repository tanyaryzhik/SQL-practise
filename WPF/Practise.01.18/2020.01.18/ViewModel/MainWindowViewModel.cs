using _2020._01._18.Commands;
using _2020._01._18.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020._01._18.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return this.employees; }
            set
            {
                if (this.employees == value)
                    return;

                this.employees = value;
                this.OnPropertyChanged(nameof(this.Employees));
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool GetCommandCanExecute(object obj)
        {
            return this.Employees.Count == 0;
        }

        private void GetCommandExecute(object obj)
        {
            this.Employees = GetEmployees();
            //foreach (var item in empCollection)
            //{
            //    this.Employees.Add(item);
            //}
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

        private ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            employees.Add(new Employee { ID = 1, Name = "Alex Mann", Department = "GIS", HireDate = "2019-12-05", IsManager = true });
            employees.Add(new Employee { ID = 2, Name = "Mary King", Department = "Marketing", HireDate = "2005-12-24", IsManager = false });
            Employee.counter = 3;
            return employees;
        }
    }
}
