namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ingredients_and_units : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Units", t => t.Unit_ID)
                .Index(t => t.Unit_ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Unit_ID", "dbo.Units");
            DropIndex("dbo.Ingredients", new[] { "Unit_ID" });
            DropTable("dbo.Units");
            DropTable("dbo.Ingredients");
        }
    }
}
