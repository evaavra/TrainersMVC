namespace TrainersMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesToDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Courses VALUES ('C# Programming')");
            Sql("INSERT INTO Courses VALUES ('Java Programming')");
            Sql("INSERT INTO Courses VALUES ('Javascript Programming')");
            Sql("INSERT INTO Courses VALUES ('Python Programming')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Courses WHERE ID IN (1,2,3,4)");
        }
    }
}
