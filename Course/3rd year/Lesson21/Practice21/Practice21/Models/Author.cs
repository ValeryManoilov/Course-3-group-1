using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice21.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorStatus { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Author() { }
        
        public Author(string authorName, string authorStatus)
        {
            AuthorName = authorName;
            AuthorStatus = authorStatus;
        }
    }
}
