using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrueCrimeRepo.Models
{
    public class TVShowCreate
    {
        [Required]
        [Display(Name = "True Crime")]
        public string SelectedTrueCrime { get; set; }
        public ICollection<SelectListItem> Crimes { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the TV Show or Documentary title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the TV Show or Documentary title.")]
        [Display(Name = "Name of TV Show or Documentary")]
        public string Title { get; set; }

        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the TV Show or Documentary.")]
        [MaxLength(300, ErrorMessage = "Please limit your description to no more than 300 characters.")]
        [Display(Name = "Description of the TV Show or Documentary")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Where you can find the show.")]
        public string Channel_OnlineStream { get; set; }

    }
}
