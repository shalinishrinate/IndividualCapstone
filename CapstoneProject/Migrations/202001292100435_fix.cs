namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsthmaActionPlans",
                c => new
                    {
                        AsthmaActionPlanId = c.Int(nullable: false, identity: true),
                        Medicine1Name = c.String(),
                        Medicine1Dosage = c.String(),
                        Medicine1Schedule = c.String(),
                        Medicine2Name = c.String(),
                        Medicine2Dosage = c.String(),
                        Medicine2Schedule = c.String(),
                        Medicine3Name = c.String(),
                        Medicine3Dosage = c.String(),
                        Medicine3Schedule = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsthmaActionPlanId)
                .ForeignKey("dbo.People", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsthmaActionPlans", "Id", "dbo.People");
            DropIndex("dbo.AsthmaActionPlans", new[] { "Id" });
            DropTable("dbo.AsthmaActionPlans");
        }
    }
}
