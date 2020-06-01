using QuizCompetition.Models;
using QuizCompetition.Repository.Common;
using QuizCompetition.Repository.Interface;
using System.Data.Entity;

namespace QuizCompetition.Repository.Impl
{
    public class NoQuesPerLeavelRoundRepository<T> : GenericRepository<T, NoQuesPerLeavelRound>, INoQuesPerLeavelRoundRepository
        where T : DbContext, new()
    {
    }
}
