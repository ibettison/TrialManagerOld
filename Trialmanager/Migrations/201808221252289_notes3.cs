namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notes3 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
                .Index(t => t.TrialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotesModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.NotesModels", new[] { "TrialId" });
            DropTable("dbo.NotesModels");
        }
    }
}
