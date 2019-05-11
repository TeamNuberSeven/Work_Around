using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();

        Message GetById(string id);

        void CreateItem(Message message);

        void UpdateItem(Message message);

        void DeleteById(string id);
    }
}
