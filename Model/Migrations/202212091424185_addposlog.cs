namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addposlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PosTransactionResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        SoftwareExecutionTime = c.DateTime(nullable: false),
                        TranType = c.Int(nullable: false),
                        ErrorCode = c.Int(nullable: false),
                        ErrorMsg = c.String(),
                        PaymentAmount = c.String(),
                        RRN = c.String(),
                        Stan = c.String(),
                        DateTime = c.String(),
                        MerchantId = c.String(),
                        TerminalId = c.String(),
                        CardNumber = c.String(),
                        MessageId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PosTransactionResults");
        }
    }
}
