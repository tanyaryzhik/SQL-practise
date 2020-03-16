using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class OrdersViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public Order SelectedOrder { get; set; }
    }
}
