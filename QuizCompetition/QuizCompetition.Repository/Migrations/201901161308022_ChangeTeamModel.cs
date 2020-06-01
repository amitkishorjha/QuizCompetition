namespace QuizCompetition.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTeamModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizTeams", "Schoolname", c => c.String());
            DropColumn("dbo.QuizTeams", "ShortName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizTeams", "ShortName", c => c.String());
            DropColumn("dbo.QuizTeams", "Schoolname");
        }
    }
}
