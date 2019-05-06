using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IAuthUserService
    {
        IEnumerable<AuthUser> GetAll();

        AuthUser GetById(string id);

        void CreateItem(AuthUser authUser);

        void UpdateItem(AuthUser authUser);

        void DeleteById(string id);
    }
}
