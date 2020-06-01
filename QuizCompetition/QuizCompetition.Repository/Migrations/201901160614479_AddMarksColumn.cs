namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarksColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizTeams", "Marks", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizTeams", "Marks");
        }
    }
}
