using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IWorkAreaService
    {
        IEnumerable<WorkArea> GetAll();

        WorkArea GetById(string id);

        void CreateItem(WorkArea workArea);

        void UpdateItem(WorkArea workArea);

        void DeleteById(string id);
    }
}
