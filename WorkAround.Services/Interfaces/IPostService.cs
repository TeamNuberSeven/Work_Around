using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Services.DTO;

namespace WorkAround.Services.Interfaces
{
    public interface IPostService 
    {
        IEnumerable<Post> GetAll();

        Post GetById(string id);

        void CreateItem(Post post);

        void UpdateItem(Post post);

        void DeleteById(string id);
    }
}
