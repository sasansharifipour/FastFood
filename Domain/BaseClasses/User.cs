﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class User
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; } = "";

        public string Family { get; set; } = "";

        public string Password { get; set; } = "";

        public bool Deleted { get; set; } = false;

        public virtual string FullName { get { return String.Format("{0} {1}", Name, Family); } }
    }
}
