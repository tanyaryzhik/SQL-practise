﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Staff
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }

        public int? ManagerId { get; set; }

        public ObservableCollection<Order> Orders { get; set; }
    }
}