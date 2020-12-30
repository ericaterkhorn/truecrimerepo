using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class PodcastDetail
    {
        public int PodcastID { get; set; }

        public int CrimeID { get; set; }
     
        [Display(Name = "Podcast Title")]
        public string Title { get; set; }
        [Display(Name = "Podcast Description")]
        public string Description { get; set; }
        [Display(Name = "Website")]
        public string WebsiteUrl { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
