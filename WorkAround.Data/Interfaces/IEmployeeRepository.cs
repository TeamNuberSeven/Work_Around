using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> All();

        Employee Get(string id);

        void Create(Employee post);

        void Update(Employee post);

        void Delete(string id);
    }
}
