using Bus.Data;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bus.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class BusDetailsApiController : ControllerBase
    {
        private readonly IBusdetailsService _busdetailsService;
        public BusDetailsApiController(IBusdetailsService busdetailsService)
        {
            _busdetailsService = busdetailsService;
        }

        public object GetAllBusDetails () {
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
    }
}
