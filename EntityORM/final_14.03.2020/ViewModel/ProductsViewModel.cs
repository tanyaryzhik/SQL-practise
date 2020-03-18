using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        private Product selectedProduct;

        public int Quantity { get; set; }

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
            //this.Quantity = from entity in context.Stocks
            //                where computed.Contains("Id1=" + entity.Id1 + "," + "Id2=" + entity.Id2)
            //                select entity
            }
        }
        private StoreDbContext context;

        public ProductsViewModel()
        {
            this.context = new StoreDbContext();
            this.Products = new ObservableCollection<Product>(
                this.context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Stocks));
        }
    }
}
