using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice21.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = new Author();
        public ICollection<ReaderBook> ReaderBooks { get; set; } = new List<ReaderBook>();

        public Book() { }

        public Book(string bookName, string description, Guid authorId, Author author)
        {
            BookName = bookName;
            Description = description;
            AuthorId = authorId;
            Author = author;
        }
    }
}
