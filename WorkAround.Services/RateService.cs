using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class RateService: IRateService
    {
        private readonly RateRepository _rateService;

        public RateService(ApplicationDbContext applicationDbContext)
        {
            _rateService = new RateRepository(applicationDbContext);
        }

        public void CreateItem(Rate rate)
        {
            _rateService.Create(rate);
        }

        public void DeleteById(string id)
        {
            _rateService.Delete(id);
        }

        public IEnumerable<Rate> GetAll()
        {
            return _rateService.All();
        }

        public Rate GetById(string id)
        {
            return _rateService.GetById(id);
        }

        public void UpdateItem(Rate rate)
        {
            _rateService.Update(rate);
        }
    }
}
