﻿using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using Xunit;
using XUnitTests.MockedRepositories;

namespace XUnitTests.RepositoryTests {
    public class AuthUserTest {
        readonly IAuthUserRepository _repository = new MockedAuthUserRepository();

        [Fact]
        public void TestAll() {
            var repoData = _repository.All();

            foreach (var entity in repoData) {
                Assert.Equal(entity, entity);
            }
        }

        [Fact]
        public void TestGetCreate() {
            var entity = new AuthUser();
            entity.Id = "testId";

            _repository.Create(entity);

            Assert.Equal(entity, _repository.Get("testId"));
        }

        [Fact]
        public void TestUpdate() {
            var entity = _repository.All().First();

            entity.Nickname = "updatedNickname";

            _repository.Update(entity);

            Assert.Equal(entity, _repository.Get(entity.Id));
        }

        [Fact]
        public void TestDelete() {
            var entity = new AuthUser();
            entity.Id = "testId";

            _repository.Create(entity);

            _repository.Delete(entity.Id);

            Assert.Null(_repository.Get(entity.Id));
        }
    }
}