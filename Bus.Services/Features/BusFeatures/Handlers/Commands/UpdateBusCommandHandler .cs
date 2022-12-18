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
    public class UpdateBusCommandHandler:IRequestHandler<UpdateBusRequestCommand, int>
    {
        private readonly IBusdetailsService _busrepo;
        public UpdateBusCommandHandler(IBusdetailsService busrepo)
        {
            _busrepo = busrepo;
        }

        public  async Task<int> Handle(UpdateBusRequestCommand request, CancellationToken cancellationToken)
        {
            var DbBus = _busrepo.GetBusbyID(request.updateBusDetailsDto.Id);
           
                DbBus.BusName = request.updateBusDetailsDto.BusName;
                DbBus.BusNo = request.updateBusDetailsDto.BusNo;
                DbBus.RouteId = request.updateBusDetailsDto.RouteId;
                _busrepo.UpdateBus(DbBus);

            return DbBus.Id;

        }
    }
}
