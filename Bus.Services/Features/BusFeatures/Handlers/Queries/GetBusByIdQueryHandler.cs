using Bus.Services.Contracts;
using Bus.Services.Dtos.Bus;
using Bus.Services.Features.BusFeatures.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bus.Services.Features.BusFeatures.Handlers.Queries
{
    public class GetBusByIdQueryHandler : IRequestHandler<GetBusByIdRequestQuery, BusDetailsDto>
    {
        private readonly IBusdetailsService _busrepo;
        public GetBusByIdQueryHandler(IBusdetailsService busrepo)
        {
            _busrepo = busrepo;
        }
        public async Task<BusDetailsDto> Handle(GetBusByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var dbBus =  _busrepo.GetBusbyID(request.Id);
            var data = new BusDetailsDto()
            {
                BusName = dbBus.BusName,
                BusNo = dbBus.BusNo,
                Id = dbBus.Id,
                RouteId=dbBus.RouteId,
                isDisable=dbBus.isDisable,
            };
            return data;
        }
    }
}
