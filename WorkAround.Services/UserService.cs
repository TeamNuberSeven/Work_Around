using System.Collections.Generic;
using Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
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
