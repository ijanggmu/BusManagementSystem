using Bus.Data;
using Bus.Services;
using Bus.Services.Contracts;
using Bus.Services.Features.BusFeatures.Requests.Commands;
using Bus.Services.Features.BusFeatures.Requests.Queries;
using Bus.Web.Controllers.Api;
using Bus.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bus.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusDetailsApiController :ControllerBase
    {
        private readonly IMediator _mediator;
        public BusDetailsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBusDetails()
        {
            //var busdetails = _busdetailsService.GetAllBus();
            //return Ok(busdetails);
            return Ok(await _mediator.Send(new GetAllBusRequestQuery()));
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetAllBusDetails(int id)
        {
            //var busdetailsByID = _busdetailsService.GetBusbyID(id);
            //return Ok(busdetailsByID);
            return Ok(await _mediator.Send(new GetBusByIdRequestQuery { Id = id }));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> create(CreateBusRequestCommand model)
        {
            var command = new CreateBusRequestCommand()
            {
                BusName = model.BusName,
                BusNo=model.BusNo,
                RouteId=model.RouteId,
            };
            return Ok(await _mediator.Send(command));
            
        }
        //[HttpGet("edit/{id?}")]
        //public object edit(int id)
        //{
        //    var edit = new BusDetailsViewModel();
        //    BusDetails details = _busdetailsService.GetBusbyID(id);
        //    edit.Id = details.Id;
        //    edit.BusName = details.BusName;
        //    edit.BusNo = details.BusNo;
        //    edit.routeId = details.RouteId;
        //    return Ok(edit);

        //}
        //[HttpDelete("delete")]
        //public void delete (int id)
        //{
        //    _busdetailsService.DeleteBus(id);
        //}
    }
}
