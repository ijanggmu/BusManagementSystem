using Bus.Data;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bus.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class BusDetailsApiController : ControllerBase
    {
        private readonly IBusdetailsService _busdetailsService;
        public BusDetailsApiController(IBusdetailsService busdetailsService)
        {
            _busdetailsService = busdetailsService;
        }
        [HttpGet]
        public object GetAllBusDetails()
        {
            var busdetails = _busdetailsService.GetAllBus();
            return Ok(busdetails);
        }

        [HttpGet("{id?}")]
        public object GetAllBusDetails(int id)
        {
            var busdetailsByID = _busdetailsService.GetBusbyID(id);
            return Ok(busdetailsByID);
        }

        [HttpPost]
        public void create(BusDetailsViewModel model)
        {
            var bus = new BusDetails();
            bus.Id = model.Id;
            bus.BusName = model.BusName;
            bus.BusNo = model.BusNo;
            bus.RouteId = model.routeId;
            _busdetailsService.AddBuss(bus);
        }
        [HttpGet("edit/{id?}")]
        public object edit(int id)
        {
            var edit = new BusDetailsViewModel();
            BusDetails details = _busdetailsService.GetBusbyID(id);
            edit.Id = details.Id;
            edit.BusName = details.BusName;
            edit.BusNo = details.BusNo;
            edit.routeId = details.RouteId;
            return Ok(edit);

        }
    }
}
