namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialFeasible : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TrialFeasibilityModels", "TrialId");
            AddForeignKey("dbo.TrialFeasibilityModels", "TrialId", "dbo.TrialsModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialFeasibilityModels", "TrialId", "dbo.TrialsModels");
            DropIndex("dbo.TrialFeasibilityModels", new[] { "TrialId" });
        }
    }
}
