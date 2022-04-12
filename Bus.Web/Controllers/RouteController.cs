using Bus.Data;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus.Web.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        public IActionResult Index()
        {
            //create a list to store result
            List<RouteViewModel> model = new List<RouteViewModel>();

            _routeService.GetAllRoute().ToList().ForEach(
                u =>
                {
                    _routeService.GetRouteById(u.Id);
                    RouteViewModel rvm = new RouteViewModel
                    {
                        Id = u.Id,
                        RouteName = u.RouteName,
                        NumberOfStops = u.NumberOfStops,
                        BusCount = u.BusCount,   
                    };
                    model.Add(rvm);
                });
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RouteViewModel rvm)
        {
            Route r = new Route()
            {
                Id = rvm.Id,
                RouteName = rvm.RouteName,
                NumberOfStops = rvm.NumberOfStops,
                BusCount = rvm.BusCount,
            };

            _routeService.InsertRoute(r);

            return View(rvm);
        }
    }
}
