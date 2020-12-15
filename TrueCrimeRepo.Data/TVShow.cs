using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Data
{
    public class TVShow
    {
        [Key]
        public int TVShowID { get; set; }

        [ForeignKey(nameof(CrimeID))]
        public virtual Crime Crime { get; set; }
        public virtual int CrimeID { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public virtual ApplicationUser Author { get; set; }
        //public virtual int ApplicationUser { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the TV Show  or Documentary title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the TV Show or Documentary title.")]
        [Display(Name = "Name of TV Show or Documentary")]
        public string Title { get; set; }

        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the show.")]
        [MaxLength(300, ErrorMessage = "Please limit your description to no more than 300 characters.")]
        [Display(Name = "Description of the TV Show or Documentary")]
        public string Description { get; set; }

        [Display(Name = "Where to find the show")]
        public string Channel_OnlineStream { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}

