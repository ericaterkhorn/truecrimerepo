using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class TVShowListItem
    {
        public int TVShowID { get; set; }

        //public string ApplicationUser { get; set; }

        //public string Crime { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public virtual ApplicationUser Author { get; set; }
        //public virtual int ApplicationUser { get; set; }


        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }

        [Display(Name = "Name of TV Show or Documentary")]
        public string Title { get; set; }

        [Display(Name = "Description of the TV Show or Documentary")]
        public string Description { get; set; }


        [Display(Name = "Where to find the show")]
        public string Channel_OnlineStream{ get; set; }

        //public DateTimeOffset CreatedUtc { get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }

    }

}
