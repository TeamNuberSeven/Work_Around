using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class EmployerService: IEmployerService
    {
        private readonly EmployerRepository _employerRepository;

        public EmployerService(ApplicationDbContext applicationDbContext)
        {
            _employerRepository = new EmployerRepository(applicationDbContext);
        }

        public void CreateItem(Employer employer)
        {
            _employerRepository.Create(employer);
        }

        public void DeleteById(string id)
        {
            _employerRepository.Delete(id);
        }

        public IEnumerable<Employer> GetAll()
        {
            return _employerRepository.All();
        }

        public Employer GetById(string id)
        {
            return _employerRepository.GetEmployerById(id);
        }

        public void UpdateItem(Employer employer)
        {
            _employerRepository.Update(employer);
        }
    }
}
