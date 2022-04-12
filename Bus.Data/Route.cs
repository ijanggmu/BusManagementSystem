using System;
using System.ComponentModel.DataAnnotations;

namespace Bus.Data
{
    public class Route : BaseEntity
    {
        public string RouteName { get; set; }
        public int NumberOfStops { get; set; }
        public int BusCount { get; set; }

    }
}
