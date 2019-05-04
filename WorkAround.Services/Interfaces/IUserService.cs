using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetById(string id);

        User GetByUserName(string username);

        void CreateItem(User item);

        void UpdateItem(User item);

        void DeleteById(string id);
    }
}
