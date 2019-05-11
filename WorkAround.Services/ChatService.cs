using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class ChatService: IChatService
    {
        private readonly ChatRepository _chatRepository;

        public ChatService(ApplicationDbContext applicationDbContext)
        {
            _chatRepository = new ChatRepository(applicationDbContext);
        }

        public void CreateItem(Chat chat)
        {
            _chatRepository.Create(chat);
        }

        public void DeleteById(string id)
        {
            _chatRepository.Delete(id);
        }

        public IEnumerable<Chat> GetAll()
        {
            return _chatRepository.All();
        }

        public Chat GetById(string id)
        {
            return _chatRepository.GetById(id);
        }

        public void UpdateItem(Chat chat)
        {
            _chatRepository.Update(chat);
        }
    }
}
