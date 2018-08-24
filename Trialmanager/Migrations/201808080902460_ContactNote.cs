namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactNote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels");
            DropIndex("dbo.ContactsModels", new[] { "NotesId" });
            AddColumn("dbo.ContactsModels", "ContactNote", c => c.String());
            DropColumn("dbo.ContactsModels", "NotesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsModels", "NotesId", c => c.Int(nullable: false));
            DropColumn("dbo.ContactsModels", "ContactNote");
            CreateIndex("dbo.ContactsModels", "NotesId");
            AddForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels", "Id", cascadeDelete: true);
        }
    }
}
