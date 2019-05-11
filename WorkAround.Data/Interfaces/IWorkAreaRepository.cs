using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IWorkAreaRepository
    {
        IEnumerable<WorkArea> All();

        WorkArea GetById(string id);

        void Create(WorkArea workArea);

        void Update(WorkArea workArea);

        void Delete(string id);
    }
}
