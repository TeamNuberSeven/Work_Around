﻿using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> All();

        User Get(string id);

        User GetByUserName(string username);

        void Create(User item);

        void Update(User item);

        void Delete(string id);
    }
}
