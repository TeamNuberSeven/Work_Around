using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IRateService
    {
        IEnumerable<Rate> GetAll();

        Rate GetById(string id);

        void CreateItem(Rate rate);

        void UpdateItem(Rate rate);

        void DeleteById(string id);
    }
}
