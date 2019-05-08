using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedEmployeeRepository : IEmployeeRepository {
        public List<Employee> Collection;

        public MockedEmployeeRepository() {
            var employee = new Employee();
            employee.CVUrl = "mockedCVUrl";
            employee.ExperienceTime = 0.7;
            employee.User = new User();
            employee.UserId = "mockedUserId";

            var workArea = new WorkArea();
            workArea.Id = "mockedId";
            workArea.Title = "mockedTitle";

            var profession = new Proffesion {Id = "mockedId", Title = "mockedName"};

            workArea.Proffesions = new List<Proffesion> {profession, profession, profession};

            employee.WorkAreas = new List<WorkArea> {workArea, workArea, workArea};

            Collection = new List<Employee> {employee, employee, employee};
        }

        public IEnumerable<Employee> All() {
            return Collection;
        }

        public Employee Get(string id) {
            return Collection.Find(e => e.UserId == id);
        }

        public void Create(Employee post) {
            Collection.Add(post);
        }

        public void Update(Employee post) {
            var index = Collection.FindIndex(e => e.UserId == post.UserId);
            Collection[index] = post;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.UserId == id);
            Collection.RemoveAt(index);
        }
    }
}