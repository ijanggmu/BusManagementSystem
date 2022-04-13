using Bus.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus.Web.Models
{
    public class TicketViewModel
    {
      public Route Route { get; set; }
      public BusDetails BusDetails { get; set; }
      public Ticket Ticket { get; set; }
    }
}
