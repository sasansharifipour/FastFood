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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.DBContext context)
        {
            context.Users.AddOrUpdate(new User() { Name = "User", Family = "Admin", Password = Hashing.Hash("12345678"), Deleted = false, ID = 1 });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
