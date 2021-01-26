using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrueCrimeRepo.Data
{
    public class Podcast
    {
       
        [Key]
        public int PodcastID { get; set; }

        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }

        //public string CrimeTitle { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the podcast title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the podcast title.")]
        [Display(Name = "Name of Podcast")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Title of Podcast Episode")]
        public string PodcastEpisodeTitle { get; set; }

        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the podcast.")]
        [MaxLength(600, ErrorMessage = "Please limit your description to no more than 600 characters.")]
        [Display(Name = "Description of the podcast")]
        public string Description { get; set; }
        
        [Required]
        [Url]
        [Display(Name = "Website URL")]
        public string WebsiteUrl { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

       

    }

}
