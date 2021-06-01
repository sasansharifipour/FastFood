namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_is_deleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foods", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderItems", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Deleted");
            DropColumn("dbo.OrderItems", "Deleted");
            DropColumn("dbo.Foods", "Deleted");
            DropColumn("dbo.Customers", "Deleted");
        }
    }
}
