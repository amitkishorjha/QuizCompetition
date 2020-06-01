using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class UserRepository<T> : GenericRepository<T, User>, IUserRepository
        where T : DbContext, new()
    {
    }
}
