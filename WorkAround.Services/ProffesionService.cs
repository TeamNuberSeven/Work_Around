using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class ProffesionService: IProffesionService
    {
        private readonly ProffesionRepository _proffesionRepository;

        public ProffesionService(ApplicationDbContext applicationDbContext)
        {
            _proffesionRepository = new ProffesionRepository(applicationDbContext);
        }

        public void CreateItem(Proffesion proffesion)
        {
            _proffesionRepository.Create(proffesion);
        }

        public void DeleteById(string id)
        {
            _proffesionRepository.Delete(id);
        }

        public IEnumerable<Proffesion> GetAll()
        {
            return _proffesionRepository.All();
        }

        public Proffesion GetById(string id)
        {
            return _proffesionRepository.GetById(id);
        }

        public void UpdateItem(Proffesion proffesion)
        {
            _proffesionRepository.Update(proffesion);
        }
    }
}
