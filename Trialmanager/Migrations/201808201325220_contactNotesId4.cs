namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNotesId4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactNotesModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactsModels", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.ContactsModels", "ContactNote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsModels", "ContactNote", c => c.String());
            DropForeignKey("dbo.ContactNotesModels", "Id", "dbo.ContactsModels");
            DropIndex("dbo.ContactNotesModels", new[] { "Id" });
            DropTable("dbo.ContactNotesModels");
        }
    }
}
