using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Data
{
    public class BusDetails : BaseEntity
    {
        public string BusName { get; set; }
        public int BusNo { get; set; }
        public string routeName { get; set; }
       
        public virtual Route Route { get; set; }
    }
}
