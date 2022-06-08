using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bus.Web.Models
{
    public class RouteViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [DisplayName("Route Name")]
        public string RouteName { get; set; }

        [DisplayName("Number Of Stops")]
        public int NumberOfStops { get; set; }

        [DisplayName("Bus Count")]
        public int BusCount { get; set; }
        public int PermitedBus { get; set; }
        public int RemainingBusPermit { get; set; }

        public string RouteMapLink { get; set; }
    }
}
