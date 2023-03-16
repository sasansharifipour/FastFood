using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class FoodOption : ILogicalDeleteable
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; } = "";

        public string TitleIfExist { get; set; } = "";

        public string TitleIfNotExist { get; set; } = "";

        public bool DefaultExist { get; set; } = true;

        public double PriceIfExist { get; set; } = 0;

        public double PercentPriceIfExist { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<ConsumeFoodOption> ConsumeFoodOptions { get; set; } = new List<ConsumeFoodOption>();

        public IEnumerable<ConsumeViewModel> ConsumeViewModels()
        {
            List<ConsumeViewModel> consumeViewModels = new List<ConsumeViewModel>();

            foreach (var item in this.ConsumeFoodOptions)
                consumeViewModels.Add(item.GetViewModel());

            if (consumeViewModels == null)
                consumeViewModels = new List<ConsumeViewModel>();

            return consumeViewModels;
        }
    }
}
