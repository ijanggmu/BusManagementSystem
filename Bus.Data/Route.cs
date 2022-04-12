using System;
using System.ComponentModel.DataAnnotations;

namespace Bus.Data
{
    public class Route : BaseEntity
    {
        public int NumberOfStops { get; set; }

        public int BusCount { get; set; }

    }
}
