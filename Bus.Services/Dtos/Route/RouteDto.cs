using Bus.Data.Common;
using Bus.Services.Dtos.Bus;
using System.Collections.Generic;

namespace Bus.Services.Dtos.Route
{
    public class RouteDto : BaseEntity
    {
        public string RouteName { get; set; }
        public int NumberOfStops { get; set; }
        public int BusCount { get; set; }
        public string RouteMapLink { get; set; }
        public ICollection<BusDetailsDto> BusDetailsDto { get; set; }
    }
}
