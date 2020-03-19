using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class OrderItemsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OrderItem> OrderItems { get; set; }

        private OrderItem selectedOrderItem;

        public OrderItem SelectedOrderItem
        {
            get
            {
                return this.selectedOrderItem;
            }
            set
            {
                if (this.selectedOrderItem == value)
                    return;
                this.selectedOrderItem = value;
                this.OnPropertyChanged(nameof(this.selectedOrderItem));
            }
        }

        public OrderItemsViewModel(ObservableCollection<OrderItem> orderItems)
        {
            this.OrderItems = orderItems;
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