using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class BookListItem
    {
        public int BookID { get; set; }

        public string ApplicationUser { get; set; }

        public int CrimeID { get; set; }

        [Display(Name = "Name of Book")]
        public string Title { get; set; }

        [Display(Name = "Description of the book")]
        public string Description { get; set; }


        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }

        //public DateTimeOffset CreatedUtc { get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
