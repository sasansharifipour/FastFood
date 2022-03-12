using CommonCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Order : ICloneable
    {
        public int ID { get; set; } = 0;

        public int CustomerID { get; set; } = 0;

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public DateTime Insert_time { get; set; }

        public DateTime? Deliver_time { get; set; }

        public int Number { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public double discount { get; set; } = 0;

        public double paying_amount { get; set; } = 0;

        public bool credit { get; set; } = false;

        public virtual double credit_amount { get {
                return Math.Max(0, OrderItems.Sum(s => s.All_Price) - discount - paying_amount);
            } }
        public virtual double credit_amount_payment
        {
            get
            {
                return Math.Max(0, paying_amount - OrderItems.Sum(s => s.All_Price));
            }
        }

        public object Clone()
        {
            Order order = new Order()
            {
                ID = ID,
                Customer = Customer,
                discount = discount,
                CustomerID = CustomerID,
                Deleted = Deleted,
                Deliver_time = Deliver_time,
                Insert_time = Insert_time,
                Number = Number,
                OrderItems = (List<OrderItem>)OrderItems.Clone<OrderItem>()
            };

            return order;
        }
    }
}
