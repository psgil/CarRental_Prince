namespace CarRental_Prince.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiatescript4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRental_Princes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarRental_Princes", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CarRental_Princes", "CarID", "dbo.Cars");
            DropIndex("dbo.CarRental_Princes", new[] { "CarID" });
            DropIndex("dbo.CarRental_Princes", new[] { "CustomerID" });
            DropTable("dbo.CarRental_Princes");
        }
    }
}
