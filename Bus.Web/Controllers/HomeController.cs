using Bus.Data;
using Bus.Repo;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db,ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var userView = from b in _db.BusDetails
                           join r in _db.Routes
                           on b.RouteId equals r.Id
                           select new BusRouteViewModel
                           {
                               routeId=r.Id,
                               BusName = b.BusName,
                               BusNo = b.BusNo,
                               RouteName = r.RouteName,
 
                           };
            return View(userView);
        }
        public IActionResult RouteDetailView(int Id)
        {
            var routeDetails = from b in _db.BusDetails
                               join r in _db.Routes
                               on b.RouteId equals r.Id
                               where b.RouteId ==Id
                               select new RouteDetailsViewModel
                               {
                                   RouteName = r.RouteName,
                                   BusName = b.BusName,
                                   TotalBus=r.BusDetails.Count()
                                   
                               };
            return View(routeDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
