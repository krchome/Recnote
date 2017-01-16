namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maintenances", "TypeOfMaintenance", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maintenances", "TypeOfMaintenance");
        }
    }
}
