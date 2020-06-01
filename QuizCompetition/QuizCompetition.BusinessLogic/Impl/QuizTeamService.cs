using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class QuizTeamService : IQuizTeamService
    {
        private readonly IQuizTeamRepository QuizTeamRepository;

        public QuizTeamService(IQuizTeamRepository QuizTeamRepository)
        {
            this.QuizTeamRepository = QuizTeamRepository;
        }

        public IQueryable<QuizTeam> GetAll()
        {
            return this.QuizTeamRepository.GetAll();
        }

        public IQueryable<QuizTeam> FindBy(System.Linq.Expressions.Expression<Func<QuizTeam, bool>> predicate)
        {
            return this.QuizTeamRepository.FindBy(predicate);
        }

        public void Add(QuizTeam entity)
        {
            this.QuizTeamRepository.Add(entity);
        }

        public void Delete(QuizTeam entity)
        {
            this.QuizTeamRepository.Delete(entity);
        }

        public void Edit(QuizTeam entity)
        {
            this.QuizTeamRepository.Edit(entity);
        }

        public void Save()
        {
            this.QuizTeamRepository.Save();
        }


    }
}
