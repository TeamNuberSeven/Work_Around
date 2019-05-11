using System.Collections.Generic;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Interfaces
{
    public interface IProffesionRepository
    {
        IEnumerable<Proffesion> All();

        Proffesion GetById(string id);

        void Create(Proffesion proffesion);

        void Update(Proffesion proffesion);

        void Delete(string id);
    }
}
