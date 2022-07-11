using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services.Features.BusFeatures.Requests.Commands
{
    public class DeleteBusRequestCommand:IRequest<int>
    {
        public int Id { get; set; }
        public bool isDisable { get; set; }

    }
}
