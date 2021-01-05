using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class BookEdit
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookAuthor { get; set; }
    }
}
