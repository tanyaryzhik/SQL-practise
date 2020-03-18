using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int ModelYear { get; set; }

        public decimal Price { get; set; }

        public ObservableCollection<Stock> Stocks { get; set; }

        public ObservableCollection<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}