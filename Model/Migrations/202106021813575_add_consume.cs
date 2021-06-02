namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_consume : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IngredientID = c.Int(nullable: false),
                        Volume = c.Double(nullable: false),
                        Food_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_ID)
                .Index(t => t.IngredientID)
                .Index(t => t.Food_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumes", "Food_ID", "dbo.Foods");
            DropForeignKey("dbo.Consumes", "IngredientID", "dbo.Ingredients");
            DropIndex("dbo.Consumes", new[] { "Food_ID" });
            DropIndex("dbo.Consumes", new[] { "IngredientID" });
            DropTable("dbo.Consumes");
        }
    }
}
