using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IChatService
    {
        IEnumerable<Chat> GetAll();

        Chat GetById(string id);

        void CreateItem(Chat chat);

        void UpdateItem(Chat chat);

        void DeleteById(string id);
    }
}
