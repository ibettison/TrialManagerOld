namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trialContact1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrialContactsModels", "ContactId", "dbo.ContactsModels");
            DropForeignKey("dbo.TrialContactsModels", "RoleId", "dbo.RolesModels");
            DropForeignKey("dbo.TrialContactsModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.TrialContactsModels", new[] { "ContactId" });
            DropIndex("dbo.TrialContactsModels", new[] { "TrialId" });
            DropIndex("dbo.TrialContactsModels", new[] { "RoleId" });
            DropTable("dbo.TrialContactsModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrialContactsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        TrialId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TrialContactsModels", "RoleId");
            CreateIndex("dbo.TrialContactsModels", "TrialId");
            CreateIndex("dbo.TrialContactsModels", "ContactId");
            AddForeignKey("dbo.TrialContactsModels", "TrialId", "dbo.TrialFeasibilityModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TrialContactsModels", "RoleId", "dbo.RolesModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TrialContactsModels", "ContactId", "dbo.ContactsModels", "Id", cascadeDelete: true);
        }
    }
}
