using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class AuthUserRepository: IAuthUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthUserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<AuthUser> All()
        {
            return _applicationDbContext.AuthUsers;
        }

        public void Create(AuthUser authUser)
        {
            _applicationDbContext.AuthUsers.Add(authUser);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var authUser = _applicationDbContext.Employees.Find(id);
            if (authUser != null)
            {
                _applicationDbContext.AuthUsers.Remove(authUser);
            }

            _applicationDbContext.SaveChanges();
        }

        public AuthUser Get(string id)
        {
            return All().FirstOrDefault(authUser => authUser.Id == id);
        }

        public void Update(AuthUser authUser)
        {
            if (authUser != null)
            {
                _applicationDbContext.AuthUsers.Update(authUser);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
