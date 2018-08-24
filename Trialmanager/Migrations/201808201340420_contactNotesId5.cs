namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId5 : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsModels", "ContactNotesId", "dbo.ContactNotesModels");
            DropIndex("dbo.ContactsModels", new[] { "ContactNotesId" });
            DropPrimaryKey("dbo.ContactNotesModels");
            AlterColumn("dbo.ContactNotesModels", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ContactsModels", "ContactNotesId");
            AddPrimaryKey("dbo.ContactNotesModels", "Id");
            CreateIndex("dbo.ContactNotesModels", "Id");
            AddForeignKey("dbo.ContactNotesModels", "Id", "dbo.ContactsModels", "Id");
        }
    }
}
