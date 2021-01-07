using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;

namespace TrueCrimeRepo.Models
{
    public class BookDetail
    {
        public int BookID { get; set; }

        //public string ApplicationUser { get; set; }

        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }

        [Display(Name = "Name of Book")]
        public string Title { get; set; }

        [Display(Name = "Description of the book")]
        public string Description { get; set; }


        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
