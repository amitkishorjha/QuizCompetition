using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class QuizLevelService : IQuizLevelService
    {
        private readonly IQuizLevelRepository quizLevelRepository;

        public QuizLevelService(IQuizLevelRepository quizLevelRepository)
        {
            this.quizLevelRepository = quizLevelRepository;
        }

        public IQueryable<QuizLevel> GetAll()
        {
            return this.quizLevelRepository.GetAll();
        }

        public IQueryable<QuizLevel> FindBy(System.Linq.Expressions.Expression<Func<QuizLevel, bool>> predicate)
        {
            return this.quizLevelRepository.FindBy(predicate);
        }

        public void Add(QuizLevel entity)
        {
            this.quizLevelRepository.Add(entity);
        }

        public void Delete(QuizLevel entity)
        {
            this.quizLevelRepository.Delete(entity);
        }

        public void Edit(QuizLevel entity)
        {
            this.quizLevelRepository.Edit(entity);
        }

        public void Save()
        {
            this.quizLevelRepository.Save();
        }


    }
}
