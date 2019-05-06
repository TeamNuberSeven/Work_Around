using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MessageRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Message> All()
        {
            return _applicationDbContext.Messages;
        }

        public void Create(Message message)
        {
            _applicationDbContext.Messages.Add(message);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var message = _applicationDbContext.Messages.Find(id);

            if (message != null)
            {
                _applicationDbContext.Messages.Remove(message);
            }
            _applicationDbContext.SaveChanges();
        }

        public Message GetById(string id)
        {
            return All().FirstOrDefault(message => message.Id == id);
        }

        public void Update(Message message)
        {
            if (message != null)
            {
                _applicationDbContext.Messages.Update(message);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
