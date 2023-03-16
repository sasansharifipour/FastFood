using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class ConsumeFoodOption : ILogicalDeleteable
    {
        public int ID { get; set; }

        public int FoodOptionID { get; set; } = 0;

        public FoodOption FoodOption { get; set; }

        public int IngredientID { get; set; } = 0;

        public Ingredient Ingredient { get; set; }

        public double Volume { get; set; } = 0;
        public bool Deleted { get; set; }

        public ConsumeViewModel GetViewModel()
        {
            ConsumeViewModel model = new ConsumeViewModel();

            model.Volume = this.Volume;
            
            if (this.Ingredient != null)
            {
                model.IngredientName = this.Ingredient.Name;

                if (this.Ingredient.Unit != null)
                    model.UnitName = this.Ingredient.Unit.Name;
            }

            return model;
        }
    }
}
