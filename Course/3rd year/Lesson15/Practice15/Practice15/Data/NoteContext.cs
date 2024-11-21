using Microsoft.EntityFrameworkCore;
using Practice15.Models;

namespace Practice15.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) {}

        public DbSet<Note> Notes { get; set; }
        public DbSet<LogObject> Logs { get; set; }
    }
}
