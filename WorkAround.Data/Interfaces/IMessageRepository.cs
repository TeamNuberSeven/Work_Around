using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> All();

        Message GetById(string id);

        void Create(Message message);

        void Update(Message message);

        void Delete(string id);
    }
}
