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
    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusRequestCommand, int>
    {
        private readonly IBusdetailsService _busrepo;
        public DeleteBusCommandHandler(IBusdetailsService busrepo)
        {
            _busrepo = busrepo;
        }
        public async Task<int> Handle(DeleteBusRequestCommand request, CancellationToken cancellationToken)
        {
           var DbBus= _busrepo.GetBusbyID(request.Id);
            if (DbBus != null) { 
                DbBus.isDisable = true;
                _busrepo.UpdateBus(DbBus);
            }
            return DbBus.Id;

        }
    }
}
