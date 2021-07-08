namespace Model.Migrations
{
    using CommonCodes;
    using Domain.BaseClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Model.DBContext context)
        {
            try
            {
                context.Users.Add(new User() { Name = "User", Family = "Admin", Password = Hashing.Hash("12345678"), Deleted = false, ID = 1 });
                context.SaveChanges();
            }
            catch(Exception e) { }
        }
    }
}
