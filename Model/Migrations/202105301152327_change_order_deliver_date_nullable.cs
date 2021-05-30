namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_order_deliver_date_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Deliver_time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Deliver_time", c => c.DateTime(nullable: false));
        }
    }
}
