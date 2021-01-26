using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class PodcastEdit
    {
        public int PodcastID { get; set; }
        public string Title { get; set; }
        [Display(Name="Title of Podcast Episode")]
        public string PodcastEpisodeTitle { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
