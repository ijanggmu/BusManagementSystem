using Bus.Data.Common;
using Bus.Services.Dtos.Common;
using Bus.Services.Dtos.Route;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bus.Services.Dtos.Bus
{
    public class CreateBusDetailsDto
    {
        public string BusName { get; set; }
        public int BusNo { get; set; }
        public int RouteId { get; set; }

    }
}
