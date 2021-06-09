using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class ConsumeViewModel
    {
        public double Volume { get; set; } = 0;

        public string IngredientName { get; set; } = "";

        public string UnitName { get; set; } = "";
    }
}
