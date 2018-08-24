namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reminder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrialRemindersModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reminder = c.String(),
                        TrialId = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
                .Index(t => t.TrialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialRemindersModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.TrialRemindersModels", new[] { "TrialId" });
            DropTable("dbo.TrialRemindersModels");
        }
    }
}
