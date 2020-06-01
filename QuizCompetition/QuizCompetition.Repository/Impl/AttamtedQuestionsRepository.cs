using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class AttamtedQuestionsRepository<T> : GenericRepository<T, AttamtedQuestions>, IAttamtedQuestionsRepository
        where T : DbContext, new()
    {
    }
}
