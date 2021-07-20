using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class OrderItem : ICloneable
    {
        public int ID { get; set; } = 0;

        public int FoodID { get; set; } = 0;

        public Food Food { get; set; }

        public List<FoodOption> FoodOptions { get; set; } = new List<FoodOption>();

        public string Name { get; set; } = "";

        public double Price { get; set; } = 0;

        public int Count { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public virtual double All_Price { get { return Price * Count; } }

        public object Clone()
        {
            OrderItem orderItem = new OrderItem()
            {
                Count = Count,
                Deleted = Deleted,
                Food = Food,
                FoodID = FoodID,
                ID = ID,
                Name = Name,
                Price = Price
            };

            return orderItem;
        }
    }
}
