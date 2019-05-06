using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IAuthUserRepository
    {
        IEnumerable<AuthUser> All();

        AuthUser Get(string id);

        void Create(AuthUser authUser);

        void Update(AuthUser authUser);

        void Delete(string id);
    }
}
