using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedProffesionRepository : IProffesionRepository {
        public List<Proffesion> Collection;

        public MockedProffesionRepository() {
            var profession = new Proffesion {Id = "mockedId", Title = "mockedName"};

            Collection = new List<Proffesion> {profession, profession, profession};
        }

        public IEnumerable<Proffesion> All() {
            return Collection;
        }

        public Proffesion GetById(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(Proffesion proffesion) {
            Collection.Add(proffesion);
        }

        public void Update(Proffesion proffesion) {
            var index = Collection.FindIndex(e => e.Id == proffesion.Id);
            Collection[index] = proffesion;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}