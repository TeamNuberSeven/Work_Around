using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IPostLikeService
    {
        IEnumerable<PostLike> GetAll();

        PostLike GetById(string id);

        void CreateItem(PostLike chat);

        void UpdateItem(PostLike chat);

        void DeleteById(string id);
    }
}
