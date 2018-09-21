namespace Trialmanager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class docFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrialDocumentsModels", "DocumentFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrialDocumentsModels", "DocumentFileName");
        }
    }
}
