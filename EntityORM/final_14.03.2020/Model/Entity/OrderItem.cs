﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

    }
}