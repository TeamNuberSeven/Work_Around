using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using WorkAround.Data.Repositories;
using WorkAround.Services.DTO;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{   
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public void Create(Post entity)
        {
            _repository.Create(entity);
            _repository.Save();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public Post Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Post> GetList()
        {
            return _repository.GetList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Post entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        
    }
}
