using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class TVShowDetail
    {
        public int TVShowID { get; set; }

        public int CrimeID { get; set; }

        [Display(Name = "Name of TV Show or Documentary")]
        public string Title { get; set; }

        [Display(Name = "Description of the TV Show or Documentary")]
        public string Description { get; set; }

        [Display(Name = "Where to find the show ")]
        public string Channel_OnlineStream { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
