namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRecordsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.TrialRecordsModels",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   DateTime = c.DateTime(nullable: false),
                   WhoChanged = c.String(),
                   OriginalValue = c.String(),
                   NewValue = c.String(),
                   FieldName = c.String(),
                   ReasonForChange = c.String(),
                   TrialId = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
               .Index(t => t.TrialId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialRecordsModels", "TrialId", "dbo.TrialsModels");
            DropIndex("dbo.TrialRecordsModels", new[] { "TrialId" });
            DropTable("dbo.TrialRecordsModels");
        }
    }
}
