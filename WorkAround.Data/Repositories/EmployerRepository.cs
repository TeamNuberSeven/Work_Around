using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class EmployerRepository: IEmployerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Employer> All()
        {
            return _applicationDbContext.Employers;
        }

        public void Create(Employer employer)
        {
            _applicationDbContext.Employers.Add(employer);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var employer = _applicationDbContext.Employers.Find(id);

            if (employer != null)
            {
                _applicationDbContext.Employers.Remove(employer);
            }
            _applicationDbContext.SaveChanges();
        }

        public Employer GetEmployerById(string id)
        {
            return All().FirstOrDefault(employer => employer.Id == id);
        }

        public void Update(Employer employer)
        {
            if (employer != null)
            {
                _applicationDbContext.Employers.Update(employer);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
