namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Is_Serving_In_Saloon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Is_Serving_In_Saloon", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Is_Serving_In_Saloon");
        }
    }
}
