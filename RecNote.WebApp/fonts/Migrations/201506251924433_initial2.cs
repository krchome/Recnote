namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Services", "ServiceTypeId");
            AddForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "ServiceTypeId" });
        }
    }
}
