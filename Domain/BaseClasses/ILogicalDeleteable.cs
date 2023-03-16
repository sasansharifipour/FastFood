using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public interface ILogicalDeleteable
    {
        bool Deleted { get; set; }
    }
}
