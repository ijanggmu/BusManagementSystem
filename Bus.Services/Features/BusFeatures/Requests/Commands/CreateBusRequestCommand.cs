using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services.Features.BusFeatures.Requests.Commands
{
    public class CreateBusRequestCommand:IRequest<int>
    {
        public string BusName { get; set; }
        public int BusNo { get; set; }
        public int RouteId { get; set; }
    }
}
