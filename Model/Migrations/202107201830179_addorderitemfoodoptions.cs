namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderitemfoodoptions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodOptions", "OrderItem_ID", "dbo.OrderItems");
            DropIndex("dbo.FoodOptions", new[] { "OrderItem_ID" });
            CreateTable(
                "dbo.OrderItemFoodOptions",
                c => new
                    {
                        OrderItem_ID = c.Int(nullable: false),
                        FoodOption_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderItem_ID, t.FoodOption_ID })
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.FoodOptions", t => t.FoodOption_ID, cascadeDelete: true)
                .Index(t => t.OrderItem_ID)
                .Index(t => t.FoodOption_ID);
            
            DropColumn("dbo.FoodOptions", "OrderItem_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodOptions", "OrderItem_ID", c => c.Int());
            DropForeignKey("dbo.OrderItemFoodOptions", "FoodOption_ID", "dbo.FoodOptions");
            DropForeignKey("dbo.OrderItemFoodOptions", "OrderItem_ID", "dbo.OrderItems");
            DropIndex("dbo.OrderItemFoodOptions", new[] { "FoodOption_ID" });
            DropIndex("dbo.OrderItemFoodOptions", new[] { "OrderItem_ID" });
            DropTable("dbo.OrderItemFoodOptions");
            CreateIndex("dbo.FoodOptions", "OrderItem_ID");
            AddForeignKey("dbo.FoodOptions", "OrderItem_ID", "dbo.OrderItems", "ID");
        }
    }
}
