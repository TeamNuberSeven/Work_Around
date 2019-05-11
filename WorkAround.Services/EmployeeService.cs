using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _repository = new EmployeeRepository(applicationDbContext);
        }
        public void CreateItem(Employee employee)
        {
            _repository.Create(employee);
        }

        public void DeleteById(string id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.All();
        }

        public Employee GetById(string id)
        {
            return _repository.Get(id);
        }

        public void UpdateItem(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
