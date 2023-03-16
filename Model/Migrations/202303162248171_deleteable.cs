namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConsumeFoodOptions", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Consumes", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consumes", "Deleted");
            DropColumn("dbo.ConsumeFoodOptions", "Deleted");
        }
    }
}
