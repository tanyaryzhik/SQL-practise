using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }
    }
}
