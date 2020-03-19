using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }

        private int quantity;

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (this.quantity == value)
                    return;
                this.quantity = value;
                this.OnPropertyChanged(nameof(this.quantity));
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (this.selectedProduct == value)
                    return;
                this.selectedProduct = value;
                this.Quantity = this.SelectedProduct.Stocks.Sum(st => st.Quantity);
            }
        }

        private StoreDbContext context;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductsViewModel()
        {
            this.context = new StoreDbContext();
            this.Products = new ObservableCollection<Product>(
                this.context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Stocks)
                .ThenInclude(st => st.Store)
                .ToList());
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
            {
                return;
            }
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}