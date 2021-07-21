namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconsumefoodoptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsumeFoodOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodOptionID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Volume = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FoodOptions", t => t.FoodOptionID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.FoodOptionID)
                .Index(t => t.IngredientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsumeFoodOptions", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.ConsumeFoodOptions", "FoodOptionID", "dbo.FoodOptions");
            DropIndex("dbo.ConsumeFoodOptions", new[] { "IngredientID" });
            DropIndex("dbo.ConsumeFoodOptions", new[] { "FoodOptionID" });
            DropTable("dbo.ConsumeFoodOptions");
        }
    }
}
