using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class ProffesionRepository: IProffesionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProffesionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Proffesion> All()
        {
            return _applicationDbContext.Proffesions;
        }

        public void Create(Proffesion proffesion)
        {
            _applicationDbContext.Proffesions.Add(proffesion);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var proffesion = _applicationDbContext.Proffesions.Find(id);

            if (proffesion != null)
            {
                _applicationDbContext.Proffesions.Remove(proffesion);
            }
            _applicationDbContext.SaveChanges();
        }

        public Proffesion GetById(string id)
        {
            return All().FirstOrDefault(proffesion => proffesion.Id == id);
        }

        public void Update(Proffesion proffesion)
        {
            if (proffesion != null)
            {
                _applicationDbContext.Proffesions.Update(proffesion);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
