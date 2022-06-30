namespace TrainersMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCodeFirstConventionsFluentApi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Trainers", "FirstName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Trainers", "LastName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "LastName", c => c.String());
            AlterColumn("dbo.Trainers", "FirstName", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String());
        }
    }
}
