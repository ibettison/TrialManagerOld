namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactsModels", "NotesId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactsModels", "NotesId");
            AddForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels");
            DropIndex("dbo.ContactsModels", new[] { "NotesId" });
            DropColumn("dbo.ContactsModels", "NotesId");
        }
    }
}
