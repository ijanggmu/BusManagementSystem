using System;
using System.ComponentModel.DataAnnotations;

namespace Bus.Data
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        public int NumberOfStops { get; set; }

        public int BusCount { get; set; }

    }
}
