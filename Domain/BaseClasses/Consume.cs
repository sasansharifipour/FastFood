using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Consume
    {
        public int ID { get; set; }

        public int IngredientID { get; set; } = 0;

        public Ingredient Ingredient { get; set; }

        public double Volume { get; set; } = 0;
    }
}
