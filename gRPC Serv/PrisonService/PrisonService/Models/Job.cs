using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonService.Models
{
    public class Job
    {
        [Required]
        public int JobID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public double ReqCol1 { get; set; }
        public double ReqCol2 { get; set; }
        public DateTime ReqCol3 { get; set; }
        public DateTime ReqCol4 { get; set; }
    }
}
