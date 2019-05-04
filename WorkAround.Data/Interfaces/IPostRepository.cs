using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IPostRepository
    {
        void Create(Post entity);

        Post Get(long id);

        IEnumerable<Post> GetList();

        void Update(Post entity);

        void Delete(long id);

        void Save();
    }
}
