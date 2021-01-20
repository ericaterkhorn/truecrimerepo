using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrueCrimeRepo.Data;

namespace TrueCrimeRepo.Data
{
    public class Crime
    {
        [Key]
        public int CrimeID { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the title.")]
        [Display(Name = "True Crime Name")]
        public string Title { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the crime.")]
        [MaxLength(2000, ErrorMessage = "Please limit your description to no more than 2,000 characters.")]
        [Display(Name = "Description of the crime")]
        public string Description { get; set; }

        //[Required]
        //public DateTime Year { get; set; }

        [MinLength(4, ErrorMessage = "Please provide the full name (first and last) of the perpetrator.")]
        [MaxLength(50, ErrorMessage = "The name is too long. Please re-enter the first and last name of the perpetrator.")]
        //[ForeignKey("Perpetrator")]
        //public int PerpetratorID { get; set; }
        //public virtual Perpetrator Perpetrator { get; set; }

        public string Perpetrator { get; set; }

        [MaxLength(50, ErrorMessage = "Please limit your location to 50 characters.")]
        [MinLength(5, ErrorMessage = "Please add additional information.")]
        [Display(Name = "Location of the crime")]
        public string Location { get; set; }

        //[Display(Name = "Is the crime solved?")]
        //public bool IsSolved { get; set; }

        [Required]
        [Display(Name = "Is the crime solved?")]
        public Solved IsCrimeSolved { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; }
        public virtual ICollection<TVShow> TVShows { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        //public virtual ICollection<Perpetrator> Perpetrators { get; set; }

    }
    public enum Solved
    {
        Yes,
        No
    }


}


