using System;
using System.Collections.Generic;
using System.Text;

namespace WorkAround.Services.Interfaces
{
    public interface IService<T, K> : IDisposable where T : class
    {
        void Create(T entity);
        IEnumerable<T> GetList();
        T Get(K id);
        void Update(T entity);
        void Delete(K id);
    }
}
