using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice21.Models;


namespace Practice21
{
    public class BookAppContext : DbContext
    {
        public BookAppContext(DbContextOptions<BookAppContext> options) : base(options) {
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Reader> readers { get; set; }
        public DbSet<ReaderBook> rbooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderBook>()
                .HasKey(p => new{ p.ReaderId, p.BookId});

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.ReaderBooks)
                .WithOne(rb => rb.Book)
                .HasForeignKey("BookId");

            modelBuilder.Entity<Reader>()
                .HasMany(r => r.ReaderBooks)
                .WithOne(rb => rb.Reader)
                .HasForeignKey("AuthorId");
        }
    }
}
