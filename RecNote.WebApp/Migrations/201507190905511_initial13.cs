namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insurances", "ApplicationUser_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insurances", "ApplicationUser_Id");
        }
    }
}
