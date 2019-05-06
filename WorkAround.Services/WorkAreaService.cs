using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class WorkAreaService: IWorkAreaService
    {
        private readonly WorkAreaRepository _workAreaRepository;

        public WorkAreaService(ApplicationDbContext applicationDbContext)
        {
            _workAreaRepository = new WorkAreaRepository(applicationDbContext);
        }

        public void CreateItem(WorkArea workArea)
        {
            _workAreaRepository.Create(workArea);
        }

        public void DeleteById(string id)
        {
            _workAreaRepository.Delete(id);
        }

        public IEnumerable<WorkArea> GetAll()
        {
            return _workAreaRepository.All();
        }

        public WorkArea GetById(string id)
        {
            return _workAreaRepository.GetById(id);
        }

        public void UpdateItem(WorkArea workArea)
        {
            _workAreaRepository.Update(workArea);
        }
    }
}
