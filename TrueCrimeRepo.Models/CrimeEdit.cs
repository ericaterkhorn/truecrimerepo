using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;

namespace TrueCrimeRepo.Models
{
    public class CrimeEdit
    {
        public int CrimeID { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }
        //public DateTime Year { get; set; }
        public string Perpetrator { get; set; }
        
        public string Location { get; set; }
        
        //public bool IsSolved { get; set; }

        [Display(Name ="Is the crime solved?")]
        public Solved IsCrimeSolved { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; }
        [Display(Name = "TV Shows and Documentaries")]
        public virtual ICollection<TVShow> TVShows { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
