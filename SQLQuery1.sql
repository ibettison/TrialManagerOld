CreateTable("dbo.TrialRecordsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(),
                        WhoChanged = c.String(),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        FieldName = c.String(),
                        ReasonForChange = c.String(),
                        TrialId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrialFeasibilityModels", t => t.TrialId, cascadeDelete: true)
                .Index(t => t.TrialId);