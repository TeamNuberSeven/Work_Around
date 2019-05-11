using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IEmployerService
    {
        IEnumerable<Employer> GetAll();

        Employer GetById(string id);

        void CreateItem(Employer employer);

        void UpdateItem(Employer employer);

        void DeleteById(string id);
    }
}
