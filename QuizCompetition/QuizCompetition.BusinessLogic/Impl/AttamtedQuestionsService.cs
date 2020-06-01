using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class AttamtedQuestionsService : IAttamtedQuestionsService
    {
        private readonly IAttamtedQuestionsRepository attamtedQuestionsRepository;

        public AttamtedQuestionsService(IAttamtedQuestionsRepository attamtedQuestionsRepository)
        {
            this.attamtedQuestionsRepository = attamtedQuestionsRepository;
        }

        public IQueryable<AttamtedQuestions> GetAll()
        {
            return this.attamtedQuestionsRepository.GetAll();
        }

        public IQueryable<AttamtedQuestions> FindBy(System.Linq.Expressions.Expression<Func<AttamtedQuestions, bool>> predicate)
        {
            return this.attamtedQuestionsRepository.FindBy(predicate);
        }

        public void Add(AttamtedQuestions entity)
        {
            this.attamtedQuestionsRepository.Add(entity);
        }

        public void Delete(AttamtedQuestions entity)
        {
            this.attamtedQuestionsRepository.Delete(entity);
        }

        public void Edit(AttamtedQuestions entity)
        {
            this.attamtedQuestionsRepository.Edit(entity);
        }

        public void Save()
        {
            this.attamtedQuestionsRepository.Save();
        }


    }
}
