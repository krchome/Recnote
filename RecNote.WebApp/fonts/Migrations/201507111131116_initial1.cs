namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceViewModels",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceTypeId = c.Int(nullable: false),
                        AccountNumber = c.String(),
                        AccountName = c.String(),
                        Address = c.String(),
                        InvoiceAmount = c.Single(nullable: false),
                        InvoiceDate = c.String(),
                        PayeeBank = c.String(),
                        PaymentMethod = c.String(),
                        ServiceTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceViewModels");
        }
    }
}
