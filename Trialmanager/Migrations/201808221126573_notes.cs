namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notes : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotesModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.NotesModels", new[] { "TrialId" });
            DropColumn("dbo.NotesModels", "TrialId");
            DropColumn("dbo.NotesModels", "DateTime");
            DropColumn("dbo.NotesModels", "Who");
        }
    }
}
