namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialSetup1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrialLocationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrialSetupModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrantFunderRef = c.String(),
                        SponsorRef = c.String(),
                        RecRef = c.String(),
                        EudractRef = c.String(),
                        IrasId = c.String(),
                        RecruitmentTarget = c.String(),
                        TrialLocationId = c.Int(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        HraDate = c.DateTime(nullable: false),
                        CtaDate = c.DateTime(nullable: false),
                        TrialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrialLocationModels", t => t.TrialLocationId, cascadeDelete: true)
                .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
                .Index(t => t.TrialLocationId)
                .Index(t => t.TrialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialSetupModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropForeignKey("dbo.TrialSetupModels", "TrialLocationId", "dbo.TrialLocationModels");
            DropIndex("dbo.TrialSetupModels", new[] { "TrialId" });
            DropIndex("dbo.TrialSetupModels", new[] { "TrialLocationId" });
            DropTable("dbo.TrialSetupModels");
            DropTable("dbo.TrialLocationModels");
        }
    }
}
