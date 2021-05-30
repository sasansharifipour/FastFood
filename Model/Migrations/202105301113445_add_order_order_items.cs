namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_order_order_items : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.FoodID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Insert_time = c.DateTime(nullable: false),
                        Deliver_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "FoodID", "dbo.Foods");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderItems", new[] { "Order_ID" });
            DropIndex("dbo.OrderItems", new[] { "FoodID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
