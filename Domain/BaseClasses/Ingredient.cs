using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Ingredient
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Unit Unit { get; set; }
    }
}
