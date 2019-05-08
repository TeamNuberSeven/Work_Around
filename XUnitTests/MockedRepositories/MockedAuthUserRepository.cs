using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using WorkAround.Services;

namespace XUnitTests.MockedRepositories
{
    class MockedAuthUserRepository: IAuthUserRepository
    {
        public IEnumerable<AuthUser> All() {
            var authUser = new AuthUser();
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

            var authUsers = new List<AuthUser> {authUser, authUser, authUser};

            return authUsers;
        }

        public AuthUser Get(string id) {
            throw new NotImplementedException();
        }

        public void Create(AuthUser authUser) {
            throw new NotImplementedException();
        }

        public void Update(AuthUser authUser) {
            throw new NotImplementedException();
        }

        public void Delete(string id) {
            throw new NotImplementedException();
        }
    }
}
