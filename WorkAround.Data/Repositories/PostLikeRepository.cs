using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class PostLikeRepository: IPostLikeRepository
    {
        private readonly ApplicationDbContext _context;

        public PostLikeRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<PostLike> All()
        {
            return _context.PostLikes;
        }

        public void Create(PostLike post)
        {
            _context.PostLikes.Add(post);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var post = _context.PostLikes.Find(id);
            if (post != null)
            {
                _context.PostLikes.Remove(post);
            }

            _context.SaveChanges();
        }

        public PostLike GetById(string id)
        {
            return All().FirstOrDefault(post => post.Id == id);
        }
        

        public void Update(PostLike post)
        {
            if (post != null)
            {
                _context.PostLikes.Update(post);
                _context.SaveChanges();
            }
        }
    }
}
