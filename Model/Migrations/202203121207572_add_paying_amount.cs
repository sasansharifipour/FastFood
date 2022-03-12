namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_paying_amount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "paying_amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "paying_amount");
        }
    }
}
