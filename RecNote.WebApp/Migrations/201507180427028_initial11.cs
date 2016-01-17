namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsuranceId = c.Int(nullable: false, identity: true),
                        InsuranceTypeId = c.Int(nullable: false),
                        CustomerNumber = c.String(nullable: false),
                        PolicyNumber = c.String(nullable: false),
                        PolicyType = c.String(nullable: false),
                        InsuredName = c.String(nullable: false),
                        PolicyStartDate = c.String(nullable: false),
                        PolicyEndDate = c.String(),
                        PremiumAmount = c.Single(nullable: false),
                        PaymentType = c.String(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        PayeeBank = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.InsuranceId);
            
            CreateTable(
                "dbo.InsuranceTypes",
                c => new
                    {
                        InsuranceTypeId = c.Int(nullable: false, identity: true),
                        InsuranceDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InsuranceTypeId);
            
            CreateTable(
                "dbo.Maintenances",
                c => new
                    {
                        MaintenanceId = c.Int(nullable: false, identity: true),
                        MaintenanceTypeId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(),
                        DetailsOfWork = c.String(nullable: false),
                        InvoiceAmount = c.Single(nullable: false),
                        InvoiceDetails = c.String(),
                        Provider = c.String(nullable: false),
                        Comments = c.String(),
                        DateDone = c.String(nullable: false),
                        DateDue = c.String(),
                    })
                .PrimaryKey(t => t.MaintenanceId)
                .ForeignKey("dbo.MaintenanceTypes", t => t.MaintenanceTypeId, cascadeDelete: true)
                .Index(t => t.MaintenanceTypeId);
            
            CreateTable(
                "dbo.MaintenanceTypes",
                c => new
                    {
                        MaintenanceTypeId = c.Int(nullable: false, identity: true),
                        MaintenanceDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaintenanceTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maintenances", "MaintenanceTypeId", "dbo.MaintenanceTypes");
            DropIndex("dbo.Maintenances", new[] { "MaintenanceTypeId" });
            DropTable("dbo.MaintenanceTypes");
            DropTable("dbo.Maintenances");
            DropTable("dbo.InsuranceTypes");
            DropTable("dbo.Insurances");
        }
    }
}
