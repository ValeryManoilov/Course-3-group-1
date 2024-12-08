using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice21.Models
{
    public class ReaderBook
    {
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public Book Book { get; set; } = new Book();
        public Reader Reader { get; set; } = new Reader();
    }
}
