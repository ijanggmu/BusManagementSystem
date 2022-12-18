using MediatR;
using Bus.Services.Features.BusFeatures.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Bus.Services.Dtos.Bus;
using System.Threading.Tasks;
using System.Threading;
using Bus.Services.Contracts;

namespace Bus.Services.Features.BusFeatures.Handlers.Queries
{
    public class GetAllBusQueryHandler : IRequestHandler<GetAllBusRequestQuery, IEnumerable<BusDetailsDto>>
    {
        private readonly IBusdetailsService _busrepo;
        public GetAllBusQueryHandler(IBusdetailsService busrepo)
        {
            _busrepo = busrepo;
        }
        public async Task<IEnumerable<BusDetailsDto>> Handle(GetAllBusRequestQuery request, CancellationToken cancellationToken)
        {
            var dbBus= _busrepo.GetAllBus();
            var BusList = new List<BusDetailsDto>();
            foreach(var item in dbBus)
            {
                var allbus = new BusDetailsDto()
                {
                    BusName = item.BusName,
                    BusNo = item.BusNo,
                    Id = item.Id,
                    RouteId = item.RouteId,
                    isDisable=item.isDisable,
                };
                BusList.Add(allbus);
            }
            return BusList;
        }
    }
}
