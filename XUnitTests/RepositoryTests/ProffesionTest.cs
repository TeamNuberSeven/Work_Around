﻿using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using Xunit;
using XUnitTests.MockedRepositories;

namespace XUnitTests.RepositoryTests {
    public class ProffesionTest {
        readonly IProffesionRepository _repository = new MockedProffesionRepository();

        [Fact]
        public void TestAll() {
            var repoData = _repository.All();

            foreach (var entity in repoData) {
                Assert.Equal(entity, entity);
            }
        }

        [Fact]
        public void TestGetCreate() {
            var entity = new Proffesion();
            entity.Id = "testId";

            _repository.Create(entity);

            Assert.Equal(entity, _repository.GetById("testId"));
        }

        [Fact]
        public void TestUpdate() {
            var entity = _repository.All().First();

            entity.Title = "updatedTitle";

            _repository.Update(entity);

            Assert.Equal(entity, _repository.GetById(entity.Id));
        }

        [Fact]
        public void TestDelete() {
            var entity = new Proffesion();
            entity.Id = "testId";

            _repository.Create(entity);

            _repository.Delete(entity.Id);

            Assert.Null(_repository.GetById(entity.Id));
        }
    }
}