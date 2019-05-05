using System;
using System.Collections.Generic;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;
using WorkAround.Data.Repositories;
using WorkAround.Services.DTO;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class PostService : IPostService
    {
        private readonly PostRepository _repository;

        public PostService(ApplicationDbContext applicationDbContext)
        {
            _repository = new PostRepository(applicationDbContext);
        }

        public void CreateItem(Post post)
        {
            if (post != null)
            {
                _repository.Create(post);
            }
        }

        public void DeleteById(string id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _repository.All();
        }

        public Post GetById(string id)
        {
            return _repository.Get(id);
        }

        public void UpdateItem(Post post)
        {
            if (post != null)
            {
                _repository.Update(post);
            }
        }
    }
}

