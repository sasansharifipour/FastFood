namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_user_registerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "User_RegisteredID", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "User_RegisteredID");
            AddForeignKey("dbo.Orders", "User_RegisteredID", "dbo.Users", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_RegisteredID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_RegisteredID" });
            DropColumn("dbo.Orders", "User_RegisteredID");
        }
    }
}
