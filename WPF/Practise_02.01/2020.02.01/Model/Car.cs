using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._02._01.Model
{
    public class Car : INotifyPropertyChanged
    {
        private string brand;
        public string Brand
        {
            get { return this.brand; }
            set
            {
                if (this.brand == value)
                    return;

                this.brand = value;
                this.OnPropertyChanged(nameof(this.Brand));
            }
        }

        private string model;
        public string Model
        {
            get { return this.model; }
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }

        private string imagePath;

        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                if (this.imagePath == value)
                    return;

                this.imagePath = value;
                this.OnPropertyChanged(nameof(this.ImagePath));
            }
        }

        private decimal price;

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (this.price == value)
                    return;

                this.price = value;
                this.OnPropertyChanged(nameof(this.Price));
            }
        }

        private string country;

        public string Country
        {
            get { return this.country; }
            set
            {
                if (this.country == value)
                    return;

                this.country = value;
                this.OnPropertyChanged(nameof(this.Country));
            }
        }

        private string color;

        public string Color
        {
            get { return this.color; }
            set
            {
                if (this.color == value)
                    return;

                this.color = value;
                this.OnPropertyChanged(nameof(this.Color));
            }
        }

        private string engineType;

        public string EngineType
        {
            get { return this.engineType; }
            set
            {
                if (this.engineType == value)
                    return;

                this.engineType = value;
                this.OnPropertyChanged(nameof(this.EngineType));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
