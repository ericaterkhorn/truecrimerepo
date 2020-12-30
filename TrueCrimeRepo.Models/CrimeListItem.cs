﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class CrimeListItem
    {
        public int CrimeID { get; set; }
        [Display(Name = "True Crime Name")]
        public string Title { get; set; }
        [Display(Name = "Description of the crime")]
        public string Description { get; set; }
        //public DateTime Year { get; set; }
        public string Perpetrator { get; set; }
        [Display(Name = "Location of the crime")]
        public string Location { get; set; }
        [Display(Name = "Is the crime solved?")]
        public bool IsSolved { get; set; }

        
        //public virtual ICollection<Podcast> CrimePodcasts { get; set; }
        //[Display(Name = "TV Shows and Documentaries")]
        //public virtual ICollection<TVShow> TVShows { get; set; }
        //public virtual ICollection<Book> Books { get; set; }

    }
}
