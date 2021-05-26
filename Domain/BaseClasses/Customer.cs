using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Customer
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; } = "";

        public string Family { get; set; } = "";

        public string Mobile { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
