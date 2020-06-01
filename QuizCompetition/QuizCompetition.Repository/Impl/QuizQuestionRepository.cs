using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class QuizQuestionRepository<T> : GenericRepository<T, QuizQuestion>, IQuizQuestionRepository
        where T : DbContext, new()
    {
    }
}
