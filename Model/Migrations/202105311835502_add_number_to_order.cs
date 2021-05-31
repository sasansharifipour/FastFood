namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_number_to_order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Number");
        }
    }
}
