namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSkipproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttamtedQuestions", "IsSkip", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttamtedQuestions", "IsSkip");
        }
    }
}
