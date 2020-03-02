using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stores.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ItemsTotal { get; set; }

        public string Phone { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryCity { get; set; }

        public string DeliveryZip { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}