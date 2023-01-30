using Bus.Data;
using Bus.Services.Contracts;
using Bus.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bus.Web.Controllers
{
    [Authorize]
    public class BusDetailsController : Controller
    {
        private readonly IBusdetailsService _busservics;
        private readonly IRouteService _services;
        private readonly ApiUrlLink _apiUrl;
        public BusDetailsController(IOptions<ApiUrlLink> options ,IBusdetailsService busservices, IRouteService services)
        {
            _services = services;
            _busservics = busservices;
            _apiUrl = options.Value;
        }
        public IActionResult Index()
        {
            var jsonData = _apiUrl.Accounting.ToString();
            var data = _busservics.GetAllBus().
                Select(x => new BusDetailsViewModel()
                {
                    Id = x.Id,
                    BusNo = x.BusNo,
                    BusName = x.BusName,
                    routeId=x.RouteId
                });
            return View(data);
    }

    //public IActionResult Authenticate()
    //{
    //    var homeClaims = new List<Claim>()
    //        {
    //            new Claim(ClaimTypes.Name,"Ejan"),
    //            new Claim(ClaimTypes.Email,"sthaejan00@gmail.com"),
    //            new Claim("grandma.Says","Ejan"),
    //        };  

    //    var licenseClaims = new List<Claim>()
    //        {
    //            new Claim(ClaimTypes.Name,"Ejan Shrestha"),
    //            new Claim("Driving License","A+"),
    //        };
    //    var grandmaIdentity = new ClaimsIdentity(homeClaims, "Grandma Identity");
    //    var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");
    //    var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });
    //    HttpContext.SignInAsync(userPrinciple);
    //    return RedirectToAction("Index");
    //}

    [HttpGet("create")]
    public IActionResult Create()
    {
        var data = _services.GetAllRoute().ToList();
        var routeToView = new List<BusDetailsViewModel>();
        foreach (var items in data)
        {
            var entity = new BusDetailsViewModel();
            entity.routeId = items.Id;
            entity.routeName = items.RouteName;
            routeToView.Add(entity);

        }
        //ViewBag.busdetails = routeToView;

        var model = new BusDetailsViewModel();
        model.routeList = routeToView;
        return View(model);
    }

    [HttpPost("create")]
    public IActionResult Create(BusDetailsViewModel model)
    {
        var bus = new BusDetails();
        bus.BusName = model.BusName;
        bus.BusNo = model.BusNo;
        bus.RouteId = model.routeId;
        _busservics.AddBuss(bus);
        return RedirectToAction("index");

    }
    public IActionResult Delete(int id)
    {
        var data = _busservics.GetBusbyID(id);
        if (data != null)
        {
            data.isDisable = true;
            _busservics.UpdateBus(data);
        };
        //_busservics.DeleteBus(id);
        return RedirectToAction("index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var edit = new BusDetailsViewModel();
        BusDetails details = _busservics.GetBusbyID(id);
        edit.Id = details.Id;
        edit.BusName = details.BusName;
        edit.BusNo = details.BusNo;
        edit.routeId = details.RouteId;
        return View(edit);

    }
    [HttpPost]
    public IActionResult Edit(BusDetailsViewModel bus)
    {
        BusDetails b = _busservics.GetBusbyID(bus.Id);
        b.BusName = bus.BusName;
        b.BusNo = bus.BusNo;
        b.RouteId = bus.routeId;
        _busservics.UpdateBus(b);
        return RedirectToAction("index");

    }
    [HttpGet("Indexs")]
    public IActionResult IndexApi()
    {
        return View();
    }

    public IActionResult Export()
    {
        List<BusDetails> studentdetails = _busservics.GetAllBus().ToList();

        var sb = new StringBuilder();
        sb.AppendLine("Bus Name,Bus No,Route Id");

        foreach (var item in studentdetails)
        {
            sb.AppendLine($"{item.BusName},{item.BusNo},{item.RouteId}");
        }
        return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "BusDetails.csv");
    }
}
}
