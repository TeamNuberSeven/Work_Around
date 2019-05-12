using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedMessageRepository : IMessageRepository {
        public List<Message> Collection;

        public MockedMessageRepository() {
            var message = new Message();
            message.Id = "mockedId";
            message.Sent = new DateTime();
            message.Text = "mockedText";
            message.Title = "mockedTitle";
            message.User = new User();

            Collection = new List<Message> {message, message, message};
        }

        public IEnumerable<Message> All() {
            return Collection;
        }

        public Message GetById(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(Message message) {
            Collection.Add(message);
        }

        public void Update(Message message) {
            var index = Collection.FindIndex(e => e.Id == message.Id);
            Collection[index] = message;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}