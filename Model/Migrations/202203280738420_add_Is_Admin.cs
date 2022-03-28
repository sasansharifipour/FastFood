namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Is_Admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Is_Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Is_Admin");
        }
    }
}
