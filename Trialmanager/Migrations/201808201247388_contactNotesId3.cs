namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactNotesModels", "ContactNotesId", "dbo.ContactsModels");
            DropIndex("dbo.ContactNotesModels", new[] { "ContactNotesId" });
            DropTable("dbo.ContactNotesModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactNotesModels",
                c => new
                    {
                        ContactNotesId = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactNotesId);
            
            CreateIndex("dbo.ContactNotesModels", "ContactNotesId");
            AddForeignKey("dbo.ContactNotesModels", "ContactNotesId", "dbo.ContactsModels", "Id");
        }
    }
}
