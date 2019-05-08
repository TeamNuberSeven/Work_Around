using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedEmployeeRepository : IEmployeeRepository {
        public List<Employee> Employees;

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

            Employees = new List<Employee> {employee, employee, employee};
        }

        public IEnumerable<Employee> All() {
            return Employees;
        }

        public Employee Get(string id) {
            return Employees.Find(employee => employee.UserId == id);
        }

        public void Create(Employee post) {
            Employees.Add(post);
        }

        public void Update(Employee post) {
            var index = Employees.FindIndex(employee => employee.Id == post.Id);
            Employees[index] = post;
        }

        public void Delete(string id) {
            var index = Employees.FindIndex(employee => employee.Id == id);
            Employees.RemoveAt(index);
        }
    }
}