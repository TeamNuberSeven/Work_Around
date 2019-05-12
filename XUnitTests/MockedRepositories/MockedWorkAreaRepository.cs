using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedWorkAreaRepository : IWorkAreaRepository {
        public List<WorkArea> Collection;

        public MockedWorkAreaRepository() {
            var workArea = new WorkArea();
            workArea.Id = "mockedId";
            workArea.Title = "mockedTitle";

            var profession = new Proffesion {Id = "mockedId", Title = "mockedName"};

            workArea.Proffesions = new List<Proffesion> {profession, profession, profession};

            Collection = new List<WorkArea> {workArea, workArea, workArea};
        }

        public IEnumerable<WorkArea> All() {
            return Collection;
        }

        public WorkArea GetById(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(WorkArea workArea) {
            Collection.Add(workArea);
        }

        public void Update(WorkArea workArea) {
            var index = Collection.FindIndex(e => e.Id == workArea.Id);
            Collection[index] = workArea;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}