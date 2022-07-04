namespace TrainersMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToTrainers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Thumbnail");
        }
    }
}
