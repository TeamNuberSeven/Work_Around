﻿using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Services.DTO;

namespace WorkAround.Services.Interfaces
{
    interface IPostService 
    {
        void Create(Post entity);

        Post Get(long id);

        IEnumerable<Post> GetList();

        void Update(Post entity);

        void Delete(long id);

        void Save();
    }
}
