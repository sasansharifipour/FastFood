namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfood_option : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TitleIfExist = c.String(),
                        TitleIfNotExist = c.String(),
                        DefaultExist = c.Boolean(nullable: false),
                        PriceIfExist = c.Double(nullable: false),
                        PercentPriceIfExist = c.Double(nullable: false),
                        OrderItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_ID)
                .Index(t => t.OrderItem_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodOptions", "OrderItem_ID", "dbo.OrderItems");
            DropIndex("dbo.FoodOptions", new[] { "OrderItem_ID" });
            DropTable("dbo.FoodOptions");
        }
    }
}
