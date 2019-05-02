using System;
using System.Collections.Generic;
using WorkAround.Data.Repositories;
using WorkAround.Services.DTO;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<PostDTO, long> _repository;
        private bool _disposed;

        public PostService(IRepository<PostDTO, long> repository)
        {
            _repository = repository;
        }

        public void Create(PostDTO entity)
        {
            _repository.Create(entity);
            _repository.Save();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public PostDTO Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<PostDTO> GetList()
        {
            return _repository.GetList();
        }

        public void Update(PostDTO entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
