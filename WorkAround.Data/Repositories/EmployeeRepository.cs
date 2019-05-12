using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<Employee> All()
        {
            return _context.Employees; ;
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            _context.SaveChanges();
        }

        public Employee Get(string id)
        {
            return All().FirstOrDefault(employee => employee.Id == id);
        }

        public void Update(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
        }
    }
}
