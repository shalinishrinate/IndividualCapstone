namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabledatatype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.People", new[] { "DoctorId" });
            AlterColumn("dbo.People", "DoctorId", c => c.Int());
            CreateIndex("dbo.People", "DoctorId");
            AddForeignKey("dbo.People", "DoctorId", "dbo.Doctors", "DoctorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.People", new[] { "DoctorId" });
            AlterColumn("dbo.People", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "DoctorId");
            AddForeignKey("dbo.People", "DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
        }
    }
}
