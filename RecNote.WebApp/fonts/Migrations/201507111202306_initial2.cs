namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceViewModels", "ApplicationUser_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceViewModels", "ApplicationUser_Id");
        }
    }
}
