namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial12 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Insurances", "InsuranceTypeId");
            AddForeignKey("dbo.Insurances", "InsuranceTypeId", "dbo.InsuranceTypes", "InsuranceTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurances", "InsuranceTypeId", "dbo.InsuranceTypes");
            DropIndex("dbo.Insurances", new[] { "InsuranceTypeId" });
        }
    }
}
