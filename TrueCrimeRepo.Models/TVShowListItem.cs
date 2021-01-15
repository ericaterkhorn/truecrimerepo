using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;

namespace TrueCrimeRepo.Models
{
    public class TVShowListItem
    {
        public int TVShowID { get; set; }

        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }

        //public string ApplicationUser { get; set; }


        [Display(Name = "Name of TV Show or Documentary")]
        public string Title { get; set; }

        [Display(Name = "Description of the TV Show or Documentary")]
        public string Description { get; set; }


        [Display(Name = "Where to find the show")]
        [Url]
        public string Channel_OnlineStream{ get; set; }

        //public DateTimeOffset CreatedUtc { get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }

    }

}
