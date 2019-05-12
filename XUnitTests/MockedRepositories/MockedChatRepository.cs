using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedChatRepository : IChatRepository {
        public List<Chat> Collection;

        public MockedChatRepository() {
            var chat = new Chat();
            chat.Id = "mockedId";

            var message = new Message {
                Id = "mockedId",
                Sent = new DateTime(),
                Text = "mockedText",
                Title = "mockedTitle",
                User = new User()
            };

            chat.Messages = new List<Message> {message, message, message};

            Collection = new List<Chat> {chat, chat, chat};
        }

        public IEnumerable<Chat> All() {
            return Collection;
        }

        public Chat GetById(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(Chat chat) {
            Collection.Add(chat);
        }

        public void Update(Chat chat) {
            var index = Collection.FindIndex(e => e.Id == chat.Id);
            Collection[index] = chat;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}