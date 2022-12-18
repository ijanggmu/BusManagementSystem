using Bus.Services.Dtos.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services.Features.BusFeatures.Requests.Commands
{
    public class UpdateBusRequestCommand:IRequest<int>
    {
        public UpdateBusDetailsDto updateBusDetailsDto;
    }
}
