using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.Data
{
    public class BusDetails : BaseEntity
    {
        [Required]
        public string BusName { get; set; }
        [Required]
        public int BusNo { get; set; }
       
        public virtual Route Route { get; set; }
    }
}
