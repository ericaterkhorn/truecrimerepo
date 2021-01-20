using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Data
{
    public class Perpetrator
    {
        [Key]
        public int PerpetratorID { get; set; }
        [Required]

        [Display(Name = "Perpetrator Name")]
        public string Name { get; set; }

        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
