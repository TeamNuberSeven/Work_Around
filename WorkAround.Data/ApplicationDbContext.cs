using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkAround.Data.Entities;

namespace WorkAround.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        

    }
}
