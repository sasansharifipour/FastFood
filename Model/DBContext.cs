using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;

namespace Model
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
