using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(ApplicationDbContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public void CreateItem(User user)
        {
            if(user != null)
            {
                _userRepository.Create(user);
            }
        }

        public void DeleteById(string id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.All();
        }

        public User GetById(string id)
        {
            return _userRepository.Get(id);
        }

        public User GetByUserName(string username)
        {
            return _userRepository.GetByUserName(username);
        }

        public void UpdateItem(User user)
        {
            if(user != null)
            {
                _userRepository.Update(user);
            }
        }
    }
}
