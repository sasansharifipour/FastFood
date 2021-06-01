using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class OrderItem
    {
        public int ID { get; set; } = 0;

        public int FoodID { get; set; } = 0;

        public Food Food { get; set; }

        public string Name { get; set; } = "";

        public double Price { get; set; } = 0;

        public int Count { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public virtual double All_Price { get { return Price * Count; } }
    }
}
