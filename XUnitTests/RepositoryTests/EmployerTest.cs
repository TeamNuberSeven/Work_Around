using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using Xunit;
using XUnitTests.MockedRepositories;

namespace XUnitTests.RepositoryTests {
    public class EmployerTest {
        readonly IEmployerRepository _repository = new MockedEmployerRepository();

        [Fact]
        public void TestAll() {
            var repoData = _repository.All();

            foreach (var entity in repoData) {
                Assert.Equal(entity, entity);
            }
        }

        [Fact]
        public void TestGetCreate() {
            var entity = new Employer();
            entity.UserId = "testId";

            _repository.Create(entity);

            Assert.Equal(entity, _repository.GetEmployerById("testId"));
        }

        [Fact]
        public void TestUpdate() {
            var entity = _repository.All().First();

            entity.JobConditions = "updatedJobConditions";

            _repository.Update(entity);

            Assert.Equal(entity, _repository.GetEmployerById(entity.UserId));
        }

        [Fact]
        public void TestDelete() {
            var entity = new Employer();
            entity.UserId = "testId";

            _repository.Create(entity);

            _repository.Delete(entity.UserId);

            Assert.Null(_repository.GetEmployerById(entity.UserId));
        }
    }
}