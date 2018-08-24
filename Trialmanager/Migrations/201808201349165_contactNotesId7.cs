namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactsModels", "ContactNotes", c => c.String());

        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsModels", "ContactNotesId", c => c.Int(nullable: false));
            DropColumn("dbo.ContactsModels", "ContactNotes");
        }
    }
}
