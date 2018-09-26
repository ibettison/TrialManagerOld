namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialSetupChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrialSetupModels", "ProjectIdentifier", c => c.String());
            AddColumn("dbo.TrialSetupModels", "ResearchDevelopmentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrialSetupModels", "ResearchDevelopmentId");
            DropColumn("dbo.TrialSetupModels", "ProjectIdentifier");
        }
    }
}
