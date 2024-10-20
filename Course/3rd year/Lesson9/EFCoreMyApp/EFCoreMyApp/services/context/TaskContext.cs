using EFCoreMyApp.services.models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMyApp.services.context
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskObject> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
