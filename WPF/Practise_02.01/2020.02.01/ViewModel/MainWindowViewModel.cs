using _2020._02._01.Model;
using _2020._02._01.Model.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020._02._01.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get { return this.cars; }
            set
            {
                if (this.cars == value)
                    return;

                this.cars = value;
                this.OnPropertyChanged(nameof(this.Cars));
            }
        }

        private Car selectedCar;
        public Car SelectedCar
        {
            get { return this.selectedCar; }
            set
            {
                if (this.selectedCar == value)
                    return;

                this.selectedCar = value;
                this.OnPropertyChanged(nameof(this.SelectedCar));
            }
        }

        private Car defaultCar;
        public Car DefaultCar
        {
            get { return this.defaultCar; }
            set
            {
                if (this.defaultCar == value)
                    return;

                this.defaultCar = value;
                this.OnPropertyChanged(nameof(this.DefaultCar));
            }
        }

        public ICommand RemoveCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public MainWindowViewModel()
        {
            this.Cars = Helper.GetCars();
            this.DefaultCar = Helper.GetDefaultCar();
            this.RemoveCommand = new RelayCommand(RemoveCommandExecute, GeneralCommandCanExecute);
            this.ResetCommand = new RelayCommand(ResetCommandExecute, GeneralCommandCanExecute);
        }

        private bool GeneralCommandCanExecute(object obj)
        {
            return this.SelectedCar != null;
        }

        private void ResetCommandExecute(object obj)
        {
            this.SelectedCar.Brand = this.DefaultCar.Brand;
            this.SelectedCar.Model = this.DefaultCar.Model;
            this.SelectedCar.ImagePath = this.DefaultCar.ImagePath;
            this.SelectedCar.Price = this.DefaultCar.Price;
            this.SelectedCar.Country = this.DefaultCar.Country;
            this.SelectedCar.Color = this.DefaultCar.Color;
            this.SelectedCar.EngineType = this.DefaultCar.EngineType;
        }

        private void RemoveCommandExecute(object obj)
        {
            this.Cars.Remove(this.SelectedCar);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
