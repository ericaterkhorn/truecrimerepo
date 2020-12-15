using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Data
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [ForeignKey(nameof(CrimeID))]
        public virtual Crime Crime { get; set; }
        public virtual int CrimeID { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public virtual ApplicationUser Author { get; set; }
        //public virtual int ApplicationUser { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please enter the full name of the book.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the book title.")]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the book.")]
        [MaxLength(300, ErrorMessage = "Please limit your description to no more than 300 characters.")]
        [Display(Name = "Description of the book")]
        public string Description { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Please enter the full name of the author.")]
        [MaxLength(30, ErrorMessage = "Please limit your description to no more than 30 characters.")]
        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }

    }
}
