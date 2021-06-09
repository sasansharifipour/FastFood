using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class FoodViewModel
    {
        public string FoodName { get; set; } = "";

        public int Count { get; set; } = 0;

        public double Price { get; set; } = 0;
    }
}
