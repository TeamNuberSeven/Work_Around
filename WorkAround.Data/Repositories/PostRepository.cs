using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkAround.Data.Entities;

namespace WorkAround.Data.Repositories
{
    public class PostRepository : IRepository<Post, long>
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
            _disposed = false;
        }

        public void Create(Post entity)
        {
            _context.Post.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var post = _context.Post.Find(id);
            if(post!= null)
            {
                _context.Post.Remove(post);
            }

            _context.SaveChanges();
        }

        public Post Get(long id)
        {
            return _context.Post
                .AsNoTracking()
//                .Include(item => item.Employee)
                .FirstOrDefault(item => item.Id == id); 
        }

        public IEnumerable<Post> GetList()
        {
            return _context.Post;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Post entity)
        {
            _context.Post.Update(entity);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
