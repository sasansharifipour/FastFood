using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Order
    {
        public int ID { get; set; } = 0;

        public int CustomerID { get; set; } = 0;

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public DateTime Insert_time { get; set; }

        public DateTime Deliver_time { get; set; }
    }
}
