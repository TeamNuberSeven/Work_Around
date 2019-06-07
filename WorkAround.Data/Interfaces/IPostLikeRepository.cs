using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IPostLikeRepository
    {
        IEnumerable<PostLike> All();

        PostLike GetById(string id);

        void Create(PostLike message);

        void Update(PostLike message);

        void Delete(string id);
    }
}
