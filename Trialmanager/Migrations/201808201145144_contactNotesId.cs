namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels");
            DropIndex("dbo.ContactsModels", new[] { "NotesId" });
            CreateTable(
                "dbo.ContactNotesModels",
                c => new
                    {
                        ContactNotesId = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactNotesId)
                .ForeignKey("dbo.ContactsModels", t => t.ContactNotesId)
                .Index(t => t.ContactNotesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactNotesModels", "ContactNotesId", "dbo.ContactsModels");
            DropIndex("dbo.ContactNotesModels", new[] { "ContactNotesId" });
            DropTable("dbo.ContactNotesModels");
            CreateIndex("dbo.ContactsModels", "NotesId");
            AddForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels", "Id", cascadeDelete: true);
        }
    }
}
