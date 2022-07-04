using System.Collections.Generic;

namespace Bus.Data
{
    public class Route : BaseEntity
    {
        public string RouteName { get; set; }
        public int NumberOfStops { get; set; }
        public int BusCount { get; set; }
        public string RouteMapLink { get; set; }
        public ICollection<BusDetails> BusDetails { get; set; }
    }
}
