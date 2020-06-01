using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class QuizTeamRepository<T> : GenericRepository<T, QuizTeam>, IQuizTeamRepository
        where T : DbContext, new()
    {
    }
}
