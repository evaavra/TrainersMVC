namespace TrainersMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesTrainersAndCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CourseID", "dbo.Courses");
            DropIndex("dbo.Trainers", new[] { "CourseID" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
