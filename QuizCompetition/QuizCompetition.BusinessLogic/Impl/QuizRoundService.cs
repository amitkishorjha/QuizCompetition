using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class QuizRoundService : IQuizRoundService
    {
        private readonly IQuizRoundRepository quizRoundRepository;

        public QuizRoundService(IQuizRoundRepository quizRoundRepository)
        {
            this.quizRoundRepository = quizRoundRepository;
        }

        public IQueryable<QuizRound> GetAll()
        {
            return this.quizRoundRepository.GetAll();
        }

        public IQueryable<QuizRound> FindBy(System.Linq.Expressions.Expression<Func<QuizRound, bool>> predicate)
        {
            return this.quizRoundRepository.FindBy(predicate);
        }

        public void Add(QuizRound entity)
        {
            this.quizRoundRepository.Add(entity);
        }

        public void Delete(QuizRound entity)
        {
            this.quizRoundRepository.Delete(entity);
        }

        public void Edit(QuizRound entity)
        {
            this.quizRoundRepository.Edit(entity);
        }

        public void Save()
        {
            this.quizRoundRepository.Save();
        }


    }
}
