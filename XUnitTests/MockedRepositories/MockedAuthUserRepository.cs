using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedAuthUserRepository : IAuthUserRepository {
        public List<AuthUser> Collection;

        public MockedAuthUserRepository() {
            var authUser = new AuthUser();
            authUser.Id = "mockedId";
            authUser.Nickname = "MockedNickname";

            var chat = new Chat();
            chat.Id = "mockedId";

            var message = new Message {
                Id = "mockedId",
                Sent = new DateTime(),
                Text = "mockedText",
                Title = "mockedTitle",
                User = authUser
            };

            chat.Messages = new List<Message> {message, message, message};

            authUser.Chats = new List<Chat> {chat, chat, chat};
            authUser.Description = "mockedDescription";

            var profession = new Proffesion();
            profession.Id = "mockedId";
            profession.Title = "mockedName";

            authUser.Proffesions = new List<Proffesion> {profession, profession, profession};

            var rate = new Rate {User = authUser, Description = "mockedDescription", Id = "mockedId", Stars = 5};

            authUser.Ratings = new List<Rate> {rate, rate, rate};

            Collection = new List<AuthUser> {authUser, authUser, authUser};
        }

        public IEnumerable<AuthUser> All() {
            return Collection;
        }

        public AuthUser Get(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(AuthUser authUser) {
            Collection.Add(authUser);
        }

        public void Update(AuthUser authUser) {
            var index = Collection.FindIndex(e => e.Id == authUser.Id);
            Collection[index] = authUser;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}