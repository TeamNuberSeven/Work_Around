using System;
using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class AuthUserService: IAuthUserService
    {
        private readonly AuthUserRepository _authUserRepository;

        public AuthUserService(ApplicationDbContext applicationDbContext)
        {
            _authUserRepository = new AuthUserRepository(applicationDbContext);
        }

        public void CreateItem(AuthUser authUser)
        {
            _authUserRepository.Create(authUser);
        }

        public void DeleteById(string id)
        {
            _authUserRepository.Delete(id);
        }

        public IEnumerable<AuthUser> GetAll()
        {
            return _authUserRepository.All();
        }

        public AuthUser GetById(string id)
        {
            return _authUserRepository.Get(id);
        }

        public void UpdateItem(AuthUser authUser)
        {
            _authUserRepository.Update(authUser);
        }
    }
}
