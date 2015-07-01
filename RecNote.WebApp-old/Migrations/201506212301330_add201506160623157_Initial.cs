namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add201506160623157_Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ApplicationUser_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ApplicationUser_Id");
        }
    }
}
