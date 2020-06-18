using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PrisonService.Models
{
    public class Location
    {
        [Required]
        public int LocationID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double ReqCol1 { get; set; }
        public double ReqCol2 { get; set; }
        public DateTime ReqCol3 { get; set; }
        public DateTime ReqCol4 { get; set; }
    }
}
