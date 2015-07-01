namespace Recnote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApplicationUser_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Phone", c => c.String());
            AddColumn("dbo.Contacts", "Mobile", c => c.String());
            DropColumn("dbo.Contacts", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "State", c => c.String());
            DropColumn("dbo.Contacts", "Mobile");
            DropColumn("dbo.Contacts", "Phone");
        }
    }
}
