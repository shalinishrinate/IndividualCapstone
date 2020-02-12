namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Capstone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsthmaActionPlans",
                c => new
                    {
                        AsthmaActionPlanId = c.Int(nullable: false, identity: true),
                        GreenMedicineName = c.Int(nullable: false),
                        GreenMedicineDosage = c.Int(nullable: false),
                        GreenMedicineSchedule = c.Int(nullable: false),
                        YellowMedicineName = c.Int(nullable: false),
                        YellowMedicineDosage = c.Int(nullable: false),
                        YellowMedicineSchedule = c.Int(nullable: false),
                        RedMedicineName = c.Int(nullable: false),
                        RedMedicineDosage = c.Int(nullable: false),
                        RedMedicineSchedule = c.Int(nullable: false),
                        NormalPeakFlowRate = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsthmaActionPlanId)
                .ForeignKey("dbo.People", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AsthmaDetails", "Id", "dbo.People");
            DropForeignKey("dbo.AsthmaActionPlans", "Id", "dbo.People");
            DropForeignKey("dbo.People", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.People", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AsthmaDetails", new[] { "Id" });
            DropIndex("dbo.Doctors", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.People", new[] { "DoctorId" });
            DropIndex("dbo.People", new[] { "ApplicationId" });
            DropIndex("dbo.AsthmaActionPlans", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AsthmaDetails");
            DropTable("dbo.Doctors");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.People");
            DropTable("dbo.AsthmaActionPlans");
        }
    }
}
