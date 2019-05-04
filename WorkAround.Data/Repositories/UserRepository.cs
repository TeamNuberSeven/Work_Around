using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<User> All()
        {
            return _applicationDbContext.Users;
        }

        public void Create(User item)
        {
            _applicationDbContext.Users.Add(item);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = _applicationDbContext.Users.Find(id);
            if (user != null)
            {
                _applicationDbContext.Users.Remove(user);
            }

            _applicationDbContext.SaveChanges();
        }

        public User Get(string id)
        {
            return All().FirstOrDefault(item => item.Id == id);
        }

        public User GetByUserName(string username)
        {
            return All().FirstOrDefault(item => item.UserName == username);
        }

        public void Update(User item)
        {
            if(item != null)
            {
                _applicationDbContext.Users.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
