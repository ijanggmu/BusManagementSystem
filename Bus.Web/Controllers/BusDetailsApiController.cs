using Bus.Services;
using Microsoft.AspNetCore.Http;
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
        public object GetAllBusDetails () {
            var busdetails = _busdetailsService.GetAllBus();
            return Ok(busdetails);
        }
    }
}
