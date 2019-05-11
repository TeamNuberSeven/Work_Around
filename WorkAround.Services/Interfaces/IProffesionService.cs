using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Services.Interfaces
{
    public interface IProffesionService
    {
        IEnumerable<Proffesion> GetAll();

        Proffesion GetById(string id);

        void CreateItem(Proffesion proffesion);

        void UpdateItem(Proffesion proffesion);

        void DeleteById(string id);
    }
}
