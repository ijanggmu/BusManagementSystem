using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Data
{
    public class Ticket : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int BusNo { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public int SeatNumber { get; set; }
    }
}
