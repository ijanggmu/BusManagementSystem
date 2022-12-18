using Bus.Services.Dtos.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services.Features.BusFeatures.Requests.Queries
{
    public class GetBusByIdRequestQuery:IRequest<BusDetailsDto>
    {
        public int Id { get; set; }
    }
}
