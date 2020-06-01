namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Decription = c.String(),
                        MarksPerQuestion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LevelId = c.Int(nullable: false),
                        RoundId = c.Int(nullable: false),
                        IsMCQ = c.Boolean(nullable: false),
                        TimePerQuestion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Option1InEnglish = c.String(),
                        Option2InEnglish = c.String(),
                        Option3InEnglish = c.String(),
                        Option4InEnglish = c.String(),
                        CorrectAnswer = c.String(nullable: false),
                        QuizId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
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
            DropTable("dbo.QuizRounds");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.QuizMasters");
            DropTable("dbo.QuizLevels");
        }
    }
}
