using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class FoodOption
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; } = "";

        public string TitleIfExist { get; set; } = "";

        public string TitleIfNotExist { get; set; } = "";

        public bool DefaultExist { get; set; } = true;

        public double PriceIfExist { get; set; } = 0;

        public double PercentPriceIfExist { get; set; } = 0;
    }
}
