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
    public class CrimeDetail
    {
        public int CrimeID { get; set; }
        
        [Display(Name = "Name of True Crime")]
        public string Title { get; set; }
        
        [Display(Name = "Description of the crime")]
        public string Description { get; set; }
        //public DateTime Year { get; set; }

        //[ForeignKey("Perpetrator")]
        //public int PerpetratorID { get; set; }
        //public virtual Perpetrator Perpetrator { get; set; }
        public string Perpetrator { get; set; }

        [Display(Name = "Location of the crime")]
        public string Location { get; set; }
        //public bool IsSolved { get; set; }

        [Display(Name = "Is the crime solved?")]
        public Solved IsCrimeSolved { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; }
        [Display(Name = "TV Shows and Documentaries")]
        public virtual ICollection<TVShow> TVShows { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
