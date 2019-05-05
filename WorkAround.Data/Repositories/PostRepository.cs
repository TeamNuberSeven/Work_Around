using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace WorkAround.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<Post> All()
        {
            return _context.Post;
        }

        public void Create(Post post)
        {
            _context.Post.Add(post);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var post = _context.Post.Find(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }

            _context.SaveChanges();
        }

        public Post Get(string id)
        {
            return All().FirstOrDefault(post => post.Id == id);
        }

        public void Update(Post post)
        {
            if (post != null)
            {
                _context.Post.Update(post);
                _context.SaveChanges();
            }
        }
    }
}
