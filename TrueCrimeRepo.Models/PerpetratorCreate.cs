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
    public class PerpetratorCreate
    {
        [Required]
        [Display(Name = "Choose the name of the perpetrator. If unsolved, choose 'unknown'.")]
        public string Name { get; set; }
        
        [ForeignKey("Crime")]
        public int CrimeID { get; set; }
        public virtual Crime Crime { get; set; }
    }
}
