namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        Organisation = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        NotesId = c.Int(nullable: false),
                        ContactStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactStatusModels", t => t.ContactStatusId, cascadeDelete: true)
                .ForeignKey("dbo.NotesModels", t => t.NotesId, cascadeDelete: true)
                .Index(t => t.NotesId)
                .Index(t => t.ContactStatusId);
            
            CreateTable(
                "dbo.PhaseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhaseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsModels", "NotesId", "dbo.NotesModels");
            DropForeignKey("dbo.ContactsModels", "ContactStatusId", "dbo.ContactStatusModels");
            DropIndex("dbo.ContactsModels", new[] { "ContactStatusId" });
            DropIndex("dbo.ContactsModels", new[] { "NotesId" });
            DropTable("dbo.PhaseModels");
            DropTable("dbo.ContactsModels");
        }
    }
}
