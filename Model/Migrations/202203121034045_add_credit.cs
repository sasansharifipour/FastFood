namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_credit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "credit", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "credit");
        }
    }
}
