using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using Xunit;
using XUnitTests.MockedRepositories;

namespace XUnitTests.RepositoryTests {
    public class MessageTest {
        readonly IMessageRepository _repository = new MockedMessageRepository();

        [Fact]
        public void TestAll() {
            var repoData = _repository.All();

            foreach (var entity in repoData) {
                Assert.Equal(entity, entity);
            }
        }

        [Fact]
        public void TestGetCreate() {
            var entity = new Message();
            entity.Id = "testId";

            _repository.Create(entity);

            Assert.Equal(entity, _repository.GetById("testId"));
        }

        [Fact]
        public void TestUpdate() {
            var entity = _repository.All().First();

            entity.Text = "updatedText";

            _repository.Update(entity);

            Assert.Equal(entity, _repository.GetById(entity.Id));
        }

        [Fact]
        public void TestDelete() {
            var entity = new Message();
            entity.Id = "testId";

            _repository.Create(entity);

            _repository.Delete(entity.Id);

            Assert.Null(_repository.GetById(entity.Id));
        }
    }
}