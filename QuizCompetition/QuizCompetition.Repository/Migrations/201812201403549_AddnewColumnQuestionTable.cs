namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnewColumnQuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizQuestions", "AcademicYear", c => c.String(nullable: false));
            AddColumn("dbo.QuizQuestions", "Option1", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option2", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option3", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option4", c => c.String());
            AddColumn("dbo.QuizQuestions", "LevelId", c => c.Int(nullable: false));
            AddColumn("dbo.QuizQuestions", "QuestionType", c => c.String(nullable: false));
            AddColumn("dbo.QuizQuestions", "RoundId", c => c.Int(nullable: false));
            AddColumn("dbo.QuizQuestions", "IsMCQ", c => c.Boolean(nullable: false));
            AddColumn("dbo.QuizQuestions", "Time", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.QuizQuestions", "DocUrl", c => c.String());
            DropColumn("dbo.QuizQuestions", "Option1InEnglish");
            DropColumn("dbo.QuizQuestions", "Option2InEnglish");
            DropColumn("dbo.QuizQuestions", "Option3InEnglish");
            DropColumn("dbo.QuizQuestions", "Option4InEnglish");
            DropColumn("dbo.QuizQuestions", "QuizId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizQuestions", "QuizId", c => c.Int(nullable: false));
            AddColumn("dbo.QuizQuestions", "Option4InEnglish", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option3InEnglish", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option2InEnglish", c => c.String());
            AddColumn("dbo.QuizQuestions", "Option1InEnglish", c => c.String());
            DropColumn("dbo.QuizQuestions", "DocUrl");
            DropColumn("dbo.QuizQuestions", "Time");
            DropColumn("dbo.QuizQuestions", "IsMCQ");
            DropColumn("dbo.QuizQuestions", "RoundId");
            DropColumn("dbo.QuizQuestions", "QuestionType");
            DropColumn("dbo.QuizQuestions", "LevelId");
            DropColumn("dbo.QuizQuestions", "Option4");
            DropColumn("dbo.QuizQuestions", "Option3");
            DropColumn("dbo.QuizQuestions", "Option2");
            DropColumn("dbo.QuizQuestions", "Option1");
            DropColumn("dbo.QuizQuestions", "AcademicYear");
        }
    }
}
