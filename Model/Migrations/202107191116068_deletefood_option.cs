namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletefood_option : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodOptions", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodOptions", "Deleted");
        }
    }
}
