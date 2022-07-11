using Bus.Data;
using Bus.Services.Contracts;
using Bus.Services.Features.BusFeatures.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bus.Services.Features.BusFeatures.Handlers.Commands
{
    public class CreateBusCommandHandler : IRequestHandler<CreateBusRequestCommand, int>
    {
        private readonly IBusdetailsService _busrepo;
        public CreateBusCommandHandler(IBusdetailsService busrepo)
        {
            _busrepo = busrepo;
        }
        public async Task<int> Handle(CreateBusRequestCommand request, CancellationToken cancellationToken)
        {
            var bus = new BusDetails();
            bus.BusName = request.BusName;
            bus.BusNo = request.BusNo;
            bus.RouteId = request.RouteId;
            _busrepo.AddBuss(bus);
            return bus.Id;
        }
    }
}
