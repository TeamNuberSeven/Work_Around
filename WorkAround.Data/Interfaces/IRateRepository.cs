using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IRateRepository
    {
        IEnumerable<Rate> All();

        Rate GetById(string id);

        void Create(Rate rate);

        void Update(Rate rate);

        void Delete(string id);
    }
}
