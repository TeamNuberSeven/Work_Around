using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IEmployerRepository
    {
        IEnumerable<Employer> All();

        Employer GetEmployerById(string id);

        void Create(Employer employer);

        void Update(Employer employer);

        void Delete(string id);

    }
}
