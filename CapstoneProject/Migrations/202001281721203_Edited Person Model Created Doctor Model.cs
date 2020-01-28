namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedPersonModelCreatedDoctorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Email", c => c.String());
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
            AddColumn("dbo.People", "StreetAddress", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 50));
            DropColumn("dbo.People", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Country", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            DropColumn("dbo.People", "StreetAddress");
            DropColumn("dbo.People", "PhoneNumber");
            DropColumn("dbo.People", "Email");
        }
    }
}
