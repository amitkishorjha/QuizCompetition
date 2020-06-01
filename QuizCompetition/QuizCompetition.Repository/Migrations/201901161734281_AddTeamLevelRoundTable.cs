namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamLevelRoundTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoQuesPerLeavelRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelId = c.Int(nullable: false),
                        RoundId = c.Int(nullable: false),
                        NoOfQuestion = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AttamtedQuestions", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.AttamtedQuestions", "LevelId", c => c.Int(nullable: false));
            AddColumn("dbo.AttamtedQuestions", "RoundId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttamtedQuestions", "RoundId");
            DropColumn("dbo.AttamtedQuestions", "LevelId");
            DropColumn("dbo.AttamtedQuestions", "TeamId");
            DropTable("dbo.NoQuesPerLeavelRounds");
        }
    }
}
