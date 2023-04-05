using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Consume : ILogicalDeleteable
    {
        public int ID { get; set; }

        public int FoodID { get; set; } 

        public Food Food { get; set; }

        public int IngredientID { get; set; }

        public Ingredient Ingredient { get; set; }

        public double Volume { get; set; }
        public bool Deleted { get; set; }

        public ConsumeViewModel ViewModel
        {
            get
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
}
