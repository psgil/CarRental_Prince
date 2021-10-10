namespace CarRental_Prince.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiatescript5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerFeedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarRental_PrinceID = c.Int(nullable: false),
                        AmountFine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FineDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarRental_Princes", t => t.CarRental_PrinceID, cascadeDelete: true)
                .Index(t => t.CarRental_PrinceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fines", "CarRental_PrinceID", "dbo.CarRental_Princes");
            DropForeignKey("dbo.CustomerFeedbacks", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Fines", new[] { "CarRental_PrinceID" });
            DropIndex("dbo.CustomerFeedbacks", new[] { "CustomerID" });
            DropTable("dbo.Fines");
            DropTable("dbo.CustomerFeedbacks");
        }
    }
}
