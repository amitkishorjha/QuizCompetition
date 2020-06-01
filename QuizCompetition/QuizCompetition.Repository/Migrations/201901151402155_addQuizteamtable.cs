namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuizteamtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 30),
                        UpdatedBy = c.String(maxLength: 30),
                        DeletedBy = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuizRounds", "NoOfQuestions", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizRounds", "NoOfQuestions");
            DropTable("dbo.QuizTeams");
        }
    }
}
