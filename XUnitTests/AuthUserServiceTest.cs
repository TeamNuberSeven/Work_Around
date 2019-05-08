using System;
using System.Collections.Generic;
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
    }
}
