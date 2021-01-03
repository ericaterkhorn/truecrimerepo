using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class PodcastListItem
    {
        public int PodcastID { get; set; }

        //public string ApplicationUser { get; set; }

        public int CrimeID { get; set; }

        [Display(Name = "Name of Podcast")]
        public string Title { get; set; }

        [Display(Name = "Description of the podcast")]
        public string Description { get; set; }

       
        [Display(Name = "Website URL")]
        public string WebsiteUrl { get; set; }

        //public DateTimeOffset CreatedUtc { get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }

    }

}
