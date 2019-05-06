using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class RateRepository: IRateRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RateRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Rate> All()
        {
            return _applicationDbContext.Ratings;
        }

        public void Create(Rate rate)
        {
            _applicationDbContext.Ratings.Add(rate);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var rate = _applicationDbContext.Ratings.Find(id);

            if (rate != null)
            {
                _applicationDbContext.Ratings.Remove(rate);
            }
            _applicationDbContext.SaveChanges();
        }

        public Rate GetById(string id)
        {
            return All().FirstOrDefault(rate => rate.Id == id);
        }

        public void Update(Rate rate)
        {
            if (rate != null)
            {
                _applicationDbContext.Ratings.Update(rate);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
