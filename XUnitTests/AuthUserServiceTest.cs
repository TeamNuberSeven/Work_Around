using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using Xunit;
using XUnitTests.MockedRepositories;

namespace XUnitTests
{
    public class AuthUserServiceTest
    {
        IAuthUserRepository repo = new MockedAuthUserRepository();

        [Fact]
        public void TestAll() {
            var repoData = repo.All();
            
            foreach (var user in repoData) {
                Assert.Equal(user, user);
            }
        }

        [Fact]
        public void TestGetCreate() {
            var authUser = new AuthUser();
            authUser.Id = "testId";

            repo.Create(authUser);
            
            Assert.Equal(authUser, repo.Get("testId"));
        }

        [Fact]
        public void TestUpdate() {
            var authUser = repo.All().First();

            authUser.Nickname = "updatedNickname";

            repo.Update(authUser);

            Assert.Equal(authUser, repo.Get(authUser.Id));
        }

        [Fact]
        public void TestDelete() {
            var authUser = new AuthUser();
            authUser.Id = "testId";

            repo.Create(authUser);

            repo.Delete(authUser.Id);

            Assert.Null(repo.Get(authUser.Id));
        }
    }
}
