using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.Models
{
    public class Worker
    {
        [Required]
        public int WorkerID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LName { get; set; }

        [Required]
        public int JobID { get; set; }
        [Required]
        public Job Job { get; set; }

        [Required]
        public int LocationID { get; set; }
        [Required]
        public Location Location { get; set; }

        public double ReqCol1 { get; set; }
        public DateTime ReqCol2 { get; set; }
    }
}
