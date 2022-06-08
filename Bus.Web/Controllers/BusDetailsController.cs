﻿using Bus.Data;
using Bus.Repo;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Bus.Web.Controllers
{
    public class BusDetailsController : Controller
    {
        private readonly IBusdetailsService _busservics;
        private readonly IRouteService _services;
        private readonly ApplicationDbContext _db;
        public BusDetailsController(IBusdetailsService busservices, IRouteService services, ApplicationDbContext db)
        {
            _services = services;
            _busservics = busservices;
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            var data = _busservics.GetAllBus().ToList();
            var busToView = new List<BusDetailsViewModel>();
            foreach(var items in data)
            {
                var entity = new BusDetailsViewModel();
                
                entity.Id = items.Id;
                entity.BusNo = items.BusNo;
                entity.BusName = items.BusName;
                entity.routeId = items.RouteId;
                busToView.Add(entity);
               
            }
            return View(busToView);
        }
        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Ejan"),
                new Claim(ClaimTypes.Email,"sthaejan00@gmail.com"),
                new Claim("grandma.Says","Ejan"),
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Ejan Shrestha"),
                new Claim("Driving License","A+"),
            };
            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");
            var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity , licenseIdentity });
            HttpContext.SignInAsync(userPrinciple);
            return RedirectToAction("Create");




        }

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

        [HttpPost]
        public IActionResult Create(BusDetailsViewModel model)
        {
            var bus = new BusDetails();
            bus.Id = model.Id;
            bus.BusName = model.BusName;
            bus.BusNo = model.BusNo;
            bus.RouteId = model.routeId;
            _busservics.AddBuss(bus);
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            _busservics.DeleteBus(id);
            return RedirectToAction(@"index");
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
        public IActionResult IndexApi()
        {
            return View();
        }

        public IActionResult Export()
        {
            List<BusDetails> studentdetails = (from s in _db.BusDetails
                                                    select new BusDetails
                                                    {
                                                        BusName = s.BusName,
                                                        BusNo = s.BusNo,
                                                        RouteId = s.RouteId,                                              
                                                 }).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("BusName,BusNo,RouteId");

            foreach (var item in studentdetails)
            {
                sb.AppendLine($"{item.BusName},{item.BusNo},{item.RouteId}");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "BusDetails.csv");
        }
    }
}
