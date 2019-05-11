using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Interfaces;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Repositories
{
    public class WorkAreaRepository: IWorkAreaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WorkAreaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<WorkArea> All()
        {
            return _applicationDbContext.WorkAreas;
        }

        public void Create(WorkArea workArea)
        {
            _applicationDbContext.WorkAreas.Add(workArea);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var workArea = _applicationDbContext.WorkAreas.Find(id);

            if (workArea != null)
            {
                _applicationDbContext.WorkAreas.Remove(workArea);
            }
            _applicationDbContext.SaveChanges();
        }

        public WorkArea GetById(string id)
        {
            return All().FirstOrDefault(workArea => workArea.Id == id);
        }

        public void Update(WorkArea workArea)
        {
            if (workArea != null)
            {
                _applicationDbContext.WorkAreas.Update(workArea);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
