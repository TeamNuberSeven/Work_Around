using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedRateRepository : IRateRepository {
        public List<Rate> Collection;

        public MockedRateRepository() {
            var rate = new Rate {User = new User(), Description = "mockedDescription", Id = "mockedId", Stars = 5};

            Collection = new List<Rate> {rate, rate, rate};
        }

        public IEnumerable<Rate> All() {
            return Collection;
        }

        public Rate GetById(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(Rate rate) {
            Collection.Add(rate);
        }

        public void Update(Rate rate) {
            var index = Collection.FindIndex(e => e.Id == rate.Id);
            Collection[index] = rate;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}