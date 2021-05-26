﻿using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Model
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DBContext") { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Food> Foods { get; set; }
    }
}
