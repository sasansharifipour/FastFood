namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_user_registerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_RegisteredID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_RegisteredID" });
            RenameColumn(table: "dbo.Orders", name: "User_RegisteredID", newName: "User_Registered_ID");
            AlterColumn("dbo.Orders", "User_Registered_ID", c => c.Int());
            CreateIndex("dbo.Orders", "User_Registered_ID");
            AddForeignKey("dbo.Orders", "User_Registered_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Registered_ID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_Registered_ID" });
            AlterColumn("dbo.Orders", "User_Registered_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "User_Registered_ID", newName: "User_RegisteredID");
            CreateIndex("dbo.Orders", "User_RegisteredID");
            AddForeignKey("dbo.Orders", "User_RegisteredID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
