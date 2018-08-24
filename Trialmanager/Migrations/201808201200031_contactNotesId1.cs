namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContactsModels", "NotesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsModels", "NotesId", c => c.Int(nullable: false));
        }
    }
}
