using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Unit : ILogicalDeleteable
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";

        public bool Deleted { get; set; } = false;
    }
}
