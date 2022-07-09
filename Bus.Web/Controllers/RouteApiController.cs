using Bus.Data;
using Bus.Services;
using Bus.Services.Contracts;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bus.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteApiController : ControllerBase
    {
        private readonly IRouteService _routeService;
        public RouteApiController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        [HttpGet]
        public object GetAllRoutes()
        {
            var routes = _routeService.GetAllRoute();
            return Ok(routes);
        }
        [HttpGet("{id?}")]
        public object GetRouteById(int id)
        {
            var route = _routeService.GetRouteById(id);
            return Ok(route);
        }
        [HttpPost]
        public void CreateRoute(RouteViewModel model)
        {
            var data = new Route();
            data.RouteName = model.RouteName;
            data.NumberOfStops = model.NumberOfStops;
            data.BusCount = model.BusCount;
            _routeService.InsertRoute(data);
        }
        [HttpGet("Edit/{id?}")]
        public object EditRoute(int id)
        {
            var route = _routeService.GetRouteById(id);
            var data = new RouteViewModel();
            data.Id = route.Id;
            data.RouteName = route.RouteName;
            data.BusCount = route.BusCount;
            return Ok(data);

        }
        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _routeService.DeleteRoute(id);
        }
    }
}
