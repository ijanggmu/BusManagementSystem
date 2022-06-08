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
            var userView = (from b in _db.BusDetails
                           join r in _db.Routes
                           on b.RouteId equals r.Id
                           select new RouteViewModel
                           {
                               Id = r.Id,
                               RouteName = r.RouteName,
                               NumberOfStops = r.NumberOfStops,
                               BusCount = r.BusCount,
                               PermitedBus = r.BusDetails.Count(),
                               RemainingBusPermit= r.BusCount- r.BusDetails.Count()


                           }).Distinct();
            //_routeService.GetAllRoute().ToList().ForEach(
            //    u =>
            //    {
            //        _routeService.GetRouteById(u.Id);
            //        RouteViewModel rvm = new RouteViewModel
            //        {
            //            Id = u.Id,
            //            RouteName = u.RouteName,
            //            NumberOfStops = u.NumberOfStops,
            //            BusCount = u.BusCount,
            //            PermitedBus=u.count()

            //        };
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
