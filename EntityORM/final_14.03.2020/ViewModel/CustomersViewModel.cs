using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class CustomersViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        private StoreDbContext context;

        public CustomersViewModel()
        {
            this.context = new StoreDbContext();
            this.Customers = new ObservableCollection<Customer>(this.context.Customers);
        }
    }
}
