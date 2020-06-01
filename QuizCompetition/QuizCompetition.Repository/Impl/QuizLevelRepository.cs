using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class QuizLevelRepository<T> : GenericRepository<T, QuizLevel>, IQuizLevelRepository
        where T : DbContext, new()
    {
    }
}
