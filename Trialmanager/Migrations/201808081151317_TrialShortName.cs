namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialShortName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrialFeasibilityModels", "TrialId", "dbo.TrialsModels");
            DropIndex("dbo.TrialFeasibilityModels", new[] { "TrialId" });
            AddColumn("dbo.TrialFeasibilityModels", "ShortName", c => c.String());
            AddColumn("dbo.TrialFeasibilityModels", "TrialTitle", c => c.String());
            DropColumn("dbo.TrialFeasibilityModels", "TrialId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrialFeasibilityModels", "TrialId", c => c.Int(nullable: false));
            DropColumn("dbo.TrialFeasibilityModels", "TrialTitle");
            DropColumn("dbo.TrialFeasibilityModels", "ShortName");
            CreateIndex("dbo.TrialFeasibilityModels", "TrialId");
            AddForeignKey("dbo.TrialFeasibilityModels", "TrialId", "dbo.TrialsModels", "Id", cascadeDelete: true);
        }
    }
}
