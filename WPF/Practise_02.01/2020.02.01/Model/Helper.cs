using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._02._01.Model
{
    public static class Helper
    {
        public static ObservableCollection<Car> GetCars()
        {
            return new ObservableCollection<Car>
            {
                new Car{Brand = "Fiat",
                    Model="Doblo",
                    ImagePath = @"C:\Users\user\source\SQL-practise\SQL-practise\WPF\Practise_02.01\2020.02.01\Model\Resources\fiat_doblo-pass.jpg",
                    Price= 5000.00m,
                    Color = "White",
                    Country = "Italy",
                    EngineType = "Diesel"},
                new Car{Brand = "Renault",
                    Model="Kangoo",
                    ImagePath = @"C:\Users\user\source\SQL-practise\SQL-practise\WPF\Practise_02.01\2020.02.01\Model\Resources\renault_kangoo.jpg",
                    Price= 5000.00m,
                    Color = "Yellow",
                    Country = "France",
                    EngineType = "Diesel"},
                new Car{Brand = "Renault",
                    Model="Scenic",
                    ImagePath = @"C:\Users\user\source\SQL-practise\SQL-practise\WPF\Practise_02.01\2020.02.01\Model\Resources\Renault-Scenic.jpg",
                    Price= 5000.00m,
                    Color = "Black",
                    Country = "Italy", 
                    EngineType = "Patrol"}
            };
        }

        public static Car GetDefaultCar()
        {
            return new Car
            {
                Brand = "Default",
                Model = "Default",
                ImagePath = "Default",
                Price = 1.00m,
                Color = "Default",
                Country = "Default",
                EngineType = "Default"
            };
        }
    }
}
