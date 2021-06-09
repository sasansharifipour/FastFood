namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_food_to_consume : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consumes", "Food_ID", "dbo.Foods");
            DropIndex("dbo.Consumes", new[] { "Food_ID" });
            RenameColumn(table: "dbo.Consumes", name: "Food_ID", newName: "FoodID");
            AlterColumn("dbo.Consumes", "FoodID", c => c.Int(nullable: false));
            CreateIndex("dbo.Consumes", "FoodID");
            AddForeignKey("dbo.Consumes", "FoodID", "dbo.Foods", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumes", "FoodID", "dbo.Foods");
            DropIndex("dbo.Consumes", new[] { "FoodID" });
            AlterColumn("dbo.Consumes", "FoodID", c => c.Int());
            RenameColumn(table: "dbo.Consumes", name: "FoodID", newName: "Food_ID");
            CreateIndex("dbo.Consumes", "Food_ID");
            AddForeignKey("dbo.Consumes", "Food_ID", "dbo.Foods", "ID");
        }
    }
}
