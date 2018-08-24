namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractTypesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseTherapyAreaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiseaseTherapyAreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrantTypeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrantTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchPassportModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ContactId = c.Int(nullable: false),
                        RenewalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactsModels", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.StaffPassportModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        ContractTypeId = c.Int(nullable: false),
                        ContractEndDate = c.DateTime(nullable: false),
                        TypeofAccessId = c.Int(nullable: false),
                        AccessExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessTypesModels", t => t.TypeofAccessId, cascadeDelete: true)
                .ForeignKey("dbo.ContactsModels", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.ContractTypesModels", t => t.ContractTypeId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.ContractTypeId)
                .Index(t => t.TypeofAccessId);
            
            CreateTable(
                "dbo.TrialContactsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        TrialId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactsModels", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.RolesModels", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.TrialsModels", t => t.TrialId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.TrialId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TrialsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        TrialTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrialFeasibilityModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrialId = c.Int(nullable: false),
                        ApplicationReference = c.String(),
                        BhNumber = c.String(),
                        TrialTypeId = c.Int(nullable: false),
                        Commercial = c.Boolean(nullable: false),
                        PhaseId = c.Int(nullable: false),
                        SampleSize = c.String(),
                        GrantTypeId = c.Int(nullable: false),
                        FundingStream = c.String(),
                        GrantDeadlineDate = c.DateTime(nullable: false),
                        UniConsultancyAgreement = c.Boolean(nullable: false),
                        NhsConsultancyAgreement = c.Boolean(nullable: false),
                        DiseaseTherapyAreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiseaseTherapyAreaModels", t => t.DiseaseTherapyAreaId, cascadeDelete: true)
                .ForeignKey("dbo.GrantTypeModels", t => t.GrantTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PhaseModels", t => t.PhaseId, cascadeDelete: true)
                .ForeignKey("dbo.TrialTypeModels", t => t.TrialTypeId, cascadeDelete: true)
                .Index(t => t.TrialTypeId)
                .Index(t => t.PhaseId)
                .Index(t => t.GrantTypeId)
                .Index(t => t.DiseaseTherapyAreaId);
            
            CreateTable(
                "dbo.TrialTypeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrialTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.TrialFeasibilityModels", "TrialTypeId", "dbo.TrialTypeModels");
            DropForeignKey("dbo.TrialFeasibilityModels", "PhaseId", "dbo.PhaseModels");
            DropForeignKey("dbo.TrialFeasibilityModels", "GrantTypeId", "dbo.GrantTypeModels");
            DropForeignKey("dbo.TrialFeasibilityModels", "DiseaseTherapyAreaId", "dbo.DiseaseTherapyAreaModels");
            DropForeignKey("dbo.TrialContactsModels", "TrialId", "dbo.TrialsModels");
            DropForeignKey("dbo.TrialContactsModels", "RoleId", "dbo.RolesModels");
            DropForeignKey("dbo.TrialContactsModels", "ContactId", "dbo.ContactsModels");
            DropForeignKey("dbo.StaffPassportModels", "ContractTypeId", "dbo.ContractTypesModels");
            DropForeignKey("dbo.StaffPassportModels", "ContactId", "dbo.ContactsModels");
            DropForeignKey("dbo.StaffPassportModels", "TypeofAccessId", "dbo.AccessTypesModels");
            DropForeignKey("dbo.ResearchPassportModels", "ContactId", "dbo.ContactsModels");
            DropIndex("dbo.TrialRecordsModels", new[] { "TrialId" });
            DropIndex("dbo.TrialFeasibilityModels", new[] { "DiseaseTherapyAreaId" });
            DropIndex("dbo.TrialFeasibilityModels", new[] { "GrantTypeId" });
            DropIndex("dbo.TrialFeasibilityModels", new[] { "PhaseId" });
            DropIndex("dbo.TrialFeasibilityModels", new[] { "TrialTypeId" });
            DropIndex("dbo.TrialContactsModels", new[] { "RoleId" });
            DropIndex("dbo.TrialContactsModels", new[] { "TrialId" });
            DropIndex("dbo.TrialContactsModels", new[] { "ContactId" });
            DropIndex("dbo.StaffPassportModels", new[] { "TypeofAccessId" });
            DropIndex("dbo.StaffPassportModels", new[] { "ContractTypeId" });
            DropIndex("dbo.StaffPassportModels", new[] { "ContactId" });
            DropIndex("dbo.ResearchPassportModels", new[] { "ContactId" });
            DropTable("dbo.TrialRecordsModels");
            DropTable("dbo.TrialTypeModels");
            DropTable("dbo.TrialFeasibilityModels");
            DropTable("dbo.TrialsModels");
            DropTable("dbo.TrialContactsModels");
            DropTable("dbo.StaffPassportModels");
            DropTable("dbo.ResearchPassportModels");
            DropTable("dbo.GrantTypeModels");
            DropTable("dbo.DiseaseTherapyAreaModels");
            DropTable("dbo.ContractTypesModels");
        }
    }
}
