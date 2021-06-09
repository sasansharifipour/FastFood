using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class ConsumeViewModel
    {
        public string IngredientName { get; set; } = "";

        public double Volume { get; set; } = 0;

        public string UnitName { get; set; } = "";
    }
}
