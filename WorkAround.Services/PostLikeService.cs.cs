using System;
using System.Collections.Generic;
using System.Text;
using WorkAround.Data;
using WorkAround.Data.Entities;
using WorkAround.Data.Repositories;
using WorkAround.Services.Interfaces;

namespace WorkAround.Services
{
    public class PostLikeService: IPostLikeService
    {
        private readonly PostLikeRepository _postLikeRepository;

        public PostLikeService(ApplicationDbContext applicationDbContext)
        {
            _postLikeRepository = new PostLikeRepository(applicationDbContext);
        }

        public void CreateItem(PostLike postlike)
        {
            _postLikeRepository.Create(postlike);
        }

        public void DeleteById(string id)
        {
            _postLikeRepository.Delete(id);
        }

        public IEnumerable<PostLike> GetAll()
        {
            return _postLikeRepository.All();
        }

        public PostLike GetById(string id)
        {
            return _postLikeRepository.GetById(id);
        }

        public void UpdateItem(PostLike postlike)
        {
            _postLikeRepository.Update(postlike);
        }
    }
}
