using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.Models
{
    public partial class Prisoner
    {
        [Required]
        public int PrisonerID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LName { get; set; }
        [Required]
        public double Age { get; set; }
        [Required]
        public DateTime SentenceDate { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int LocationID { get; set; }
        [Required]
        public Location Location { get; set; }
    }
}
