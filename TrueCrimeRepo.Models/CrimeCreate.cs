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
    public class CrimeCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please re-enter the full name of the title.")]
        [MaxLength(100, ErrorMessage = "The title is too long. Please re-enter the title.")]
        [Display(Name = "Enter the name of the true crime")]
        public string Title { get; set; }
        
        [Required]
        [MinLength(4, ErrorMessage = "Please provide a minimum one sentence description of the crime.")]
        [MaxLength(2000, ErrorMessage = "Please limit your description to no more than 2,000 characters.")]
        [Display(Name = "Enter a description of the true crime")]
        public string Description { get; set; }
        
        //public string UserID { get; set; }

        //[Required]
        //public DateTime Year { get; set; }

        [MinLength(4, ErrorMessage = "Please provide the full name (first and last) of the perpetrator.")]
        [MaxLength(50, ErrorMessage = "The name is too long. Please re-enter the first and last name of the perpetrator.")]
        [Display(Name = "If the crime is solved, enter the first and last name of the perpetrator. If unsolved, please list 'unknown'.")]
        public string Perpetrator { get; set; }
        //[ForeignKey("Perpetrator")]
        //public int PerpetratorID { get; set; }
        //public virtual Perpetrator Perpetrator { get; set; }

        [MaxLength(50, ErrorMessage = "Please limit your location to 50 characters.")]
        [MinLength(5, ErrorMessage = "Please add additional information.")]
        [Display(Name = "Enter the US city and state of the crime")]
        public string Location { get; set; }

        [Display(Name = "Is the crime solved? Please select an option.")]
        public Solved IsCrimeSolved { get; set; }
    }

    //public class PerpetratorsList
    //{
    //    protected override void Seed(Perpetrator)
    //    {
    //        var perpetrators = new List<Perpetrator>
    //        {
    //            new Perpetrator{Name="Ted Bundy"},
    //            new Perpetrator{Name="John Wayne Gacy"}
    //        };
    //        perpetrators.ForEach(s => ApplicationDbContext.Perpetrators.Add(s));
    //        App.SaveChanges();

    //    }
    //}
}
