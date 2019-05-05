using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(string id);

        void CreateItem(Employee employee);

        void UpdateItem(Employee employee);

        void DeleteById(string id);
    }
}
