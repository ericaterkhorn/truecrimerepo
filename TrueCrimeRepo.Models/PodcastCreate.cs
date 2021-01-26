using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrueCrimeRepo.Data;

namespace TrueCrimeRepo.Models
{
    public class PodcastCreate
    {

        //[Required]
        //[Display(Name = "True Crime")]
        ////public string SelectedTrueCrime { get; set; }
        //public IEnumerable<SelectListItem> Crimes { get; set; }

        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the podcast title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the podcast title.")]
        [Display(Name = "Name of Podcast")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Title of Podcast Episode")]
        public string PodcastEpisodeTitle { get; set; }

        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the podcast.")]
        [MaxLength(300, ErrorMessage = "Please limit your description to no more than 300 characters.")]
        [Display(Name = "Description of the podcast")]
        public string Description { get; set; }

        [Required]
        [Url]
        [Display(Name = "Website URL")]
        public string WebsiteUrl { get; set; }


    }
}

