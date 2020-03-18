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
    public class CustomersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (this.selectedCustomer == value)
                    return;
                this.selectedCustomer = value;
                this.OnPropertyChanged(nameof(this.selectedCustomer));
                this.OrdersViewModel = new OrdersViewModel(this.selectedCustomer.Orders);
                //this.OrdersViewModel.Orders = new ObservableCollection<Order>(this.SelectedCustomer.Orders);
            }
        }
        private OrdersViewModel ordersViewModel;
        public OrdersViewModel OrdersViewModel
        {
            get
            {
                return this.ordersViewModel;
            }
            set
            {
                if (this.ordersViewModel == value)
                    return;
                this.ordersViewModel = value;
                this.OnPropertyChanged(nameof(this.ordersViewModel));
             }
        }

        private StoreDbContext context;

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomersViewModel()
        {
            this.context = new StoreDbContext();
            this.Customers = new ObservableCollection<Customer>(
                this.context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
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
