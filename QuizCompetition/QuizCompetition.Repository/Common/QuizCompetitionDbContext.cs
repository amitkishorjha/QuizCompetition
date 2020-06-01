using QuizCompetition.Models;
using System.Data.Entity;

namespace QuizCompetition.Repository.Common
{
    public class QuizCompetitionDbContext : DbContext
    {
        public QuizCompetitionDbContext() : base("QuizCompetitionDbContext")
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<QuizLevel> QuizLevel { get; set; }

        public DbSet<QuizQuestion> QuizQuestion { get; set; }

        public DbSet<QuizRound> QuizRound { get; set; }

        public DbSet<QuizMaster> QuizMaster { get; set; }

        public DbSet<AttamtedQuestions> AttamtedQuestions { get; set; }

        public DbSet<QuizTeam> QuizTeams { get; set; }

        public DbSet<NoQuesPerLeavelRound> NoQuesPerLeavelRounds { get; set; }

    }
}
