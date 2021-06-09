using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Food
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; } = "";

        public double Price { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public List<Consume> Consumes { get; set; }

        public IEnumerable<ConsumeViewModel> ConsumeViewModels()
        {
            List<ConsumeViewModel> consumeViewModels = new List<ConsumeViewModel>();

            foreach (var item in this.Consumes)
                consumeViewModels.Add(item.GetViewModel());

            if (consumeViewModels == null)
                consumeViewModels = new List<ConsumeViewModel>();

            return consumeViewModels;
        }
    }
}
