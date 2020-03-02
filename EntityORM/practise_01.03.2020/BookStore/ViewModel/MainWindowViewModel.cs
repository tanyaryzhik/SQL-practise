using BookStore_DAL;
using BookStore_DAL.Model;
using BookStore_DAL.Model.Commands;
using BookStore_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace BookStore.ViewModel
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

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private GenericRepositry<Car> repository;

        public MainWindowViewModel()
        {
            this.RemoveCommand = new RelayCommand(RemoveCommandExecute, GeneralCommandCanExecute);
            this.ResetCommand = new RelayCommand(ResetCommandExecute, GeneralCommandCanExecute);
            this.AddCommand = new RelayCommand(AddCommandExecute);
            this.SaveCommand = new RelayCommand(SaveCommandExecute);
            this.repository = new GenericRepositry<Car>();
            this.Cars = new ObservableCollection<Car>(repository.Get());
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
            this.repository.Delete(this.SelectedCar);
            this.Cars.Remove(this.SelectedCar);
            this.repository.Save();
        }

        private void SaveCommandExecute(object obj)
        {
            this.repository.Save();
        }

        private void AddCommandExecute(object obj)
        {
            Car addedCar = (new Car
            {
                Brand = "Default",
                Model = "Default",
                ImagePath = "Default",
                Price = 1.00m,
                Color = "Default",
                Country = "Default",
                EngineType = "Default"
            });
            this.Cars.Add(addedCar);
            this.repository.Add(addedCar);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}