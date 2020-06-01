namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttamtedQuestionstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttamtedQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        TeamName = c.String(),
                        Marks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AcademicYear = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AttamtedQuestions");
        }
    }
}
