using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class ChatRepository: IChatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ChatRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Chat> All()
        {
            return _applicationDbContext.Chats;
        }

        public void Create(Chat chat)
        {
            _applicationDbContext.Chats.Add(chat);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var chat = _applicationDbContext.Chats.Find(id);

            if (chat != null)
            {
                _applicationDbContext.Chats.Remove(chat);
            }
            _applicationDbContext.SaveChanges();
        }

        public Chat GetById(string id)
        {
            return All().FirstOrDefault(chat => chat.Id == id);
        }

        public void Update(Chat chat)
        {
            if (chat != null)
            {
                _applicationDbContext.Chats.Update(chat);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
