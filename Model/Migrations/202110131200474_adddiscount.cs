namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "discount");
        }
    }
}
