namespace Model.Migrations
{
    using CommonCodes;
    using Domain.BaseClasses;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBContext context)
        {
            try
            {
                var user = context.Users.FirstOrDefault(s => s.Name == "User" && s.Family == "Admin");
                if (user == null)
                {
                    context.Users.Add(new User() { Name = "User", Family = "Admin",
                        Password = Hashing.Hash("12345678"), Deleted = false, Is_Admin = true });
                    context.SaveChanges();
                }
                else if (!user.Is_Admin || user.Deleted)
                {
                    user.Is_Admin = true;
                    user.Deleted = false;

                    context.Users.AddOrUpdate(user);
                    context.SaveChanges();
                }
            }
            catch { }
        }
    }
}
