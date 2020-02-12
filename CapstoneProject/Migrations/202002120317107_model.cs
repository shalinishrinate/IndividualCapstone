namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AsthmaDetails", "AsthmaAttackDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AsthmaDetails", "AsthmaAttackNumber", c => c.Int(nullable: false));
            DropColumn("dbo.AsthmaDetails", "AsthmaAttacks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AsthmaDetails", "AsthmaAttacks", c => c.Int(nullable: false));
            DropColumn("dbo.AsthmaDetails", "AsthmaAttackNumber");
            DropColumn("dbo.AsthmaDetails", "AsthmaAttackDate");
        }
    }
}
