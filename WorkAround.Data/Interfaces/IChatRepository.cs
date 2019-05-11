using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IChatRepository
    {
        IEnumerable<Chat> All();

        Chat GetById(string id);

        void Create(Chat chat);

        void Update(Chat chat);

        void Delete(string id);
    }
}
