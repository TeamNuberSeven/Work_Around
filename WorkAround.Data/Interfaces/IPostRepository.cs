using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> All();

        Post Get(int id);

        void Create(Post post);

        void Update(Post post);

        void Delete(int id);
    }
}
