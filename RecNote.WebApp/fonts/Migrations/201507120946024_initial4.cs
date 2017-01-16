namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ServiceViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceViewModels",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceTypeId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(),
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
    }
}
