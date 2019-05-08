using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedChatRepository : IChatRepository {
        public List<Chat> Chats;

        public MockedChatRepository() {
            var chat = new Chat();
            chat.Id = "mockedId";

            var message = new Message {
                Id = "mockedId",
                Sent = new DateTime(),
                Text = "mockedText",
                Title = "mockedTitle",
                User = new AuthUser()
            };

            chat.Messages = new List<Message> {message, message, message};

            Chats = new List<Chat> {chat, chat, chat};
        }

        public IEnumerable<Chat> All() {
            return Chats;
        }

        public Chat GetById(string id) {
            return Chats.Find(chat => chat.Id == id);
        }

        public void Create(Chat chat) {
            Chats.Add(chat);
        }

        public void Update(Chat chat) {
            var index = Chats.FindIndex(c => c.Id == chat.Id);
            Chats[index] = chat;
        }

        public void Delete(string id) {
            var index = Chats.FindIndex(c => c.Id == id);
            Chats.RemoveAt(index);
        }
    }
}