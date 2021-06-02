namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_delete_field_ingredients_and_units : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Unit_ID", "dbo.Units");
            DropIndex("dbo.Ingredients", new[] { "Unit_ID" });
            RenameColumn(table: "dbo.Ingredients", name: "Unit_ID", newName: "UnitID");
            AddColumn("dbo.Ingredients", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Units", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Ingredients", "UnitID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredients", "UnitID");
            AddForeignKey("dbo.Ingredients", "UnitID", "dbo.Units", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "UnitID", "dbo.Units");
            DropIndex("dbo.Ingredients", new[] { "UnitID" });
            AlterColumn("dbo.Ingredients", "UnitID", c => c.Int());
            DropColumn("dbo.Units", "Deleted");
            DropColumn("dbo.Ingredients", "Deleted");
            RenameColumn(table: "dbo.Ingredients", name: "UnitID", newName: "Unit_ID");
            CreateIndex("dbo.Ingredients", "Unit_ID");
            AddForeignKey("dbo.Ingredients", "Unit_ID", "dbo.Units", "ID");
        }
    }
}
