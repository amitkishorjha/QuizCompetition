using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class NoQuesPerLeavelRoundService : INoQuesPerLeavelRoundService
    {
        private readonly INoQuesPerLeavelRoundRepository noQuesPerLeavelRoundRepository;

        public NoQuesPerLeavelRoundService(INoQuesPerLeavelRoundRepository noQuesPerLeavelRoundRepository)
        {
            this.noQuesPerLeavelRoundRepository = noQuesPerLeavelRoundRepository;
        }

        public IQueryable<NoQuesPerLeavelRound> GetAll()
        {
            return this.noQuesPerLeavelRoundRepository.GetAll();
        }

        public IQueryable<NoQuesPerLeavelRound> FindBy(System.Linq.Expressions.Expression<Func<NoQuesPerLeavelRound, bool>> predicate)
        {
            return this.noQuesPerLeavelRoundRepository.FindBy(predicate);
        }

        public void Add(NoQuesPerLeavelRound entity)
        {
            this.noQuesPerLeavelRoundRepository.Add(entity);
        }

        public void Delete(NoQuesPerLeavelRound entity)
        {
            this.noQuesPerLeavelRoundRepository.Delete(entity);
        }

        public void Edit(NoQuesPerLeavelRound entity)
        {
            this.noQuesPerLeavelRoundRepository.Edit(entity);
        }

        public void Save()
        {
            this.noQuesPerLeavelRoundRepository.Save();
        }


    }
}
