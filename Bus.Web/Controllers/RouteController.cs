using Bus.Data;
using Bus.Repo;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDbContext _db;
        public RouteController(ApplicationDbContext db,IRouteService routeService)
        {
            _routeService = routeService;
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userView = (from r in _db.Routes
                           join b in _db.BusDetails
                           on r.Id equals b.RouteId into n
                            from m in n.DefaultIfEmpty()
                            select new RouteViewModel
                           {
                               Id = r.Id,
                               RouteName = r.RouteName,
                               NumberOfStops = r.NumberOfStops,
                               BusCount = r.BusCount,
                               PermitedBus = r.BusDetails.Count(),
                               RemainingBusPermit= r.BusCount- r.BusDetails.Count(),
                               RouteMapLink=r.RouteMapLink,
                           }).Distinct();
          
            return View(userView);
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
                RouteName = rvm.RouteName,
                NumberOfStops = rvm.NumberOfStops,
                BusCount = rvm.BusCount,
                RouteMapLink = rvm.RouteMapLink,
            };

            //passing Category obj into the InserUser() function
            _routeService.InsertRoute(r);
            if (r.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(rvm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RouteViewModel rvm = new RouteViewModel();
            if(id != 0)
            {
                Route obj = _routeService.GetRouteById(id);
                rvm.RouteName = obj.RouteName;
                rvm.NumberOfStops = obj.NumberOfStops;
                rvm.BusCount = obj.BusCount;
            }
             
            return View(rvm);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(RouteViewModel model)
        {
            Route rvm = _routeService.GetRouteById(model.Id);
            rvm.RouteName = model.RouteName;
            rvm.NumberOfStops = model.NumberOfStops;
            rvm.BusCount = model.BusCount;

            _routeService.UpdateRoute(rvm);

            if(model.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            RouteViewModel rvm = new RouteViewModel();
            if (id != 0)
            {
                Route obj = _routeService.GetRouteById(id);
                rvm.RouteName = obj.RouteName;
                rvm.NumberOfStops = obj.NumberOfStops;
                rvm.BusCount = obj.BusCount;
            }

            return View(rvm);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int id)
        {
            _routeService.DeleteRoute(id);

            return RedirectToAction("Index");
        }
    
    }
}
