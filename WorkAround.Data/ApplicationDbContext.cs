using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkAround.Data.Entities;

namespace WorkAround.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<WorkArea> WorkAreas { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Proffesion> Proffesions { get; set; }
        public DbSet<Rate> Ratings { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(p => p.Employer)
                .WithOne(i => i.User)
                .HasForeignKey<Employer>(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Employee)
                .WithOne(i => i.User)
                .HasForeignKey<Employee>(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Ratings)
                .WithOne(i => i.User)               
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Chats)
                .WithOne(i => i.User)
                .HasForeignKey(b => b.UserId);
        }


    }
}
