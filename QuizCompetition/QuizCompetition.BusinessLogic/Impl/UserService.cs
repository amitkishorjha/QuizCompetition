using QuizCompetition.BusinessLogic.Interface;
using QuizCompetition.Models;
using QuizCompetition.Repository.Interface;
using System;
using System.Linq;

namespace QuizCompetition.BusinessLogic.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepository.GetAll();
        }

        public IQueryable<User> FindBy(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            return this.userRepository.FindBy(predicate);
        }

        public void Add(User entity)
        {
            this.userRepository.Add(entity);
        }

        public void Delete(User entity)
        {
            this.userRepository.Delete(entity);
        }

        public void Edit(User entity)
        {
            this.userRepository.Edit(entity);
        }

        public void Save()
        {
            this.userRepository.Save();
        }


    }
}
