using Bus.Repo;
using Bus.Services;
using Bus.Services.Constant;
using Bus.Services.Contracts;
using Bus.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IBusdetailsService _busRepository;
        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger,IBusdetailsService busRepository)
        {
            _busRepository = busRepository;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            //var userView = from b in _db.BusDetails
            //               join r in _db.Routes
            //               on b.RouteId equals r.Id
            //               select new BusRouteViewModel
            //               {
            //                   routeId = r.Id,
            //                   BusName = b.BusName,
            //                   BusNo = b.BusNo,
            //                   RouteName = r.RouteName,
            //               };

            var newData = _busRepository.GetDataForHome().Select(p => new BusRouteViewModel
            {
                routeId = p.RouteId,
                BusName = p.BusName,
                BusNo = p.BusNo,
                RouteName = p.Route.RouteName,
            });
            return View(newData);
        }
        public IActionResult RouteDetailView(int Id)
        {
            var routeDetails = from b in _db.BusDetails
                               join r in _db.Routes
                               on b.RouteId equals r.Id
                               where b.RouteId == Id
                               select new RouteDetailsViewModel
                               {
                                   RouteName = r.RouteName,
                                   BusNo = b.BusNo,
                                   BusName = b.BusName,
                                   TotalBus = r.BusDetails.Count
                               };
            return View(routeDetails);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BusDetailsViewModel bus)
        {
            return View();
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(Credentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (credentials.UserName == "admin" && credentials.Password == "password")
            {
                var homeClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Ejan"),
                new Claim(ClaimTypes.Email,"sthaejan00@gmail.com"),
                new Claim("grandma.Says","Ejan"),
                new Claim("Role","Admin"),
                new Claim("EmployeeDate","2022-12-20")
            };

                var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Ejan Shrestha"),
                new Claim("Driving License","A+"),
            };
                var grandmaIdentity = new ClaimsIdentity(homeClaims, "Grandma Identity");
                var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");
                var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = credentials.IsRememberMe
                };
                await HttpContext.SignInAsync(userPrinciple, authProperties);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CommonConstanst.CookieName);
            return RedirectToAction("Index");
        }
    }
}
