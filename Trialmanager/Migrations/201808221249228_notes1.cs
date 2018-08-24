namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notes1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NotesModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.NotesModels", new[] { "TrialId" });
            DropTable("dbo.NotesModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NotesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Who = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        TrialId = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.NotesModels", "TrialId");
            AddForeignKey("dbo.NotesModels", "TrialId", "dbo.TrialFeasibilityModels", "Id", cascadeDelete: true);
        }
    }
}
