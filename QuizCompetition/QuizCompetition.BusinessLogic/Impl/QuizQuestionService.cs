using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IQuizQuestionRepository quizQuestionRepository;

        public QuizQuestionService(IQuizQuestionRepository quizQuestionRepository)
        {
            this.quizQuestionRepository = quizQuestionRepository;
        }

        public IQueryable<QuizQuestion> GetAll()
        {
            return this.quizQuestionRepository.GetAll();
        }

        public IQueryable<QuizQuestion> FindBy(System.Linq.Expressions.Expression<Func<QuizQuestion, bool>> predicate)
        {
            return this.quizQuestionRepository.FindBy(predicate);
        }

        public void Add(QuizQuestion entity)
        {
            this.quizQuestionRepository.Add(entity);
        }

        public void Delete(QuizQuestion entity)
        {
            this.quizQuestionRepository.Delete(entity);
        }

        public void Edit(QuizQuestion entity)
        {
            this.quizQuestionRepository.Edit(entity);
        }

        public void Save()
        {
            this.quizQuestionRepository.Save();
        }


    }
}
