
using Microsoft.EntityFrameworkCore;
using Practice27.Models;

namespace Practice27.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
