using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class OrderItemsViewModel
    {
        public ObservableCollection<OrderItem> OrderItems { get; set; }

        public OrderItem SelectedOrderItem { get; set; }
    }
}
