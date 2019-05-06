using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class MessageService: IMessageService
    {
        private readonly MessageRepository _messageRepository;

        public MessageService(ApplicationDbContext applicationDbContext)
        {
            _messageRepository = new MessageRepository(applicationDbContext);
        }

        public void CreateItem(Message message)
        {
            _messageRepository.Create(message);
        }

        public void DeleteById(string id)
        {
            _messageRepository.Delete(id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.All();
        }

        public Message GetById(string id)
        {
            return _messageRepository.GetById(id);
        }

        public void UpdateItem(Message message)
        {
            _messageRepository.Update(message);
        }
    }
}
