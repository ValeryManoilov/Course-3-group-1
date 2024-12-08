using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practice21.Models
{
    public class Reader
    {
        public Guid Id  { get; set; }
        public string ReaderName { get; set; }
        public string ReaderEmail { get; set; }
        public ICollection<ReaderBook> ReaderBooks { get; set; } = new List<ReaderBook>();
    }
}
