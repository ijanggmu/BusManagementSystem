using Bus.Data;
using Bus.Services.Contracts;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bus.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RouteApi : ControllerBase
    {
        private readonly IRouteService _routeservice;
        public RouteApi(IRouteService routeservice)
        {
            _routeservice = routeservice;
        }
        public object GetAllRoutes()
        {
            var routeAll = _routeservice.GetAllRoute();
            return Ok(routeAll);
        }
        [HttpGet("{id?}")]
        public object GetRouteById(int id)
        {
            var routeById = _routeservice.GetRouteById(id);
            return Ok(routeById);
        }
        [HttpPost]
        public object CreateRoute(RouteViewModel model)
        {
            var data = new Route();
            data.RouteName = model.RouteName;
            data.NumberOfStops = model.NumberOfStops;
            data.BusCount = model.BusCount;
            return Ok(data);
        }
    }
}
