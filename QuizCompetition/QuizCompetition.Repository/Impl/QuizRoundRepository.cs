using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class QuizRoundRepository<T> : GenericRepository<T, QuizRound>, IQuizRoundRepository
        where T : DbContext, new()
    {
    }
}
