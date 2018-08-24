namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commercial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrialFeasibilityModels", "Commercial", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrialFeasibilityModels", "Commercial", c => c.Boolean(nullable: false));
        }
    }
}
