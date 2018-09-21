namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Documents1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTypesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrialDocumentsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                        DocumentLink = c.String(),
                        DocumentVersion = c.String(),
                        DocumentType = c.Int(nullable: false),
                        DocumentDescription = c.String(),
                        TrialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypesModels", t => t.DocumentType, cascadeDelete: true)
                .Index(t => t.DocumentType)
                .Index(t => t.TrialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrialDocumentsModels", "DocumentType", "dbo.DocumentTypesModels");
            DropForeignKey("dbo.TrialDocumentsModels", "TrialId", "dbo.TrialFeasibilityModels");
            DropIndex("dbo.TrialDocumentsModels", new[] { "TrialId" });
            DropIndex("dbo.TrialDocumentsModels", new[] { "DocumentType" });
            DropTable("dbo.TrialDocumentsModels");
            DropTable("dbo.DocumentTypesModels");
        }
    }
}
