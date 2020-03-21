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
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private OrderItemsViewModel orderItemsViewModel;

        public OrderItemsViewModel OrderItemsViewModel
        {
            get
            {
                return this.orderItemsViewModel;
            }
            set
            {
                if (this.orderItemsViewModel == value)
                    return;
                this.orderItemsViewModel = value;
                this.OnPropertyChanged(nameof(this.OrderItemsViewModel));
            }
        }

        public ObservableCollection<Order> orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                if (this.orders == value)
                    return;
                this.orders = value;
                this.OnPropertyChanged(nameof(this.Orders));
            }
        }

        private Order selectedOrder;

        public OrdersViewModel(ObservableCollection<Order> orders)
        {
            this.orders = orders;
        }

        public Order SelectedOrder
        {
            get
            {
                return this.selectedOrder;
            }
            set
            {
                if (this.selectedOrder == value)
                    return;
                this.selectedOrder = value;
                this.OnPropertyChanged(nameof(this.SelectedOrder));
                this.OrderItemsViewModel = new OrderItemsViewModel(this.SelectedOrder.OrderItems);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
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