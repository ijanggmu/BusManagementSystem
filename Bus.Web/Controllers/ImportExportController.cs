using Bus.Repo;
using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus.Web.Controllers
{
    public class ImportExportController : Controller
    {
        private readonly IBusdetailsService _busservics;
        private readonly IRouteService _services;
        private readonly ApplicationDbContext _db;
        public ImportExportController(ApplicationDbContext db, IBusdetailsService busservices, IRouteService services)
        {
            _db = db;
            _services = services;
            _busservics = busservices;
        }
        public IActionResult Index()
        {
            var data = _busservics.GetAllBus().ToList();
            var busToView = new List<BusDetailsViewModel>();
            foreach (var items in data)
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

        public IActionResult Export()
        {
            List<object> busdetails = (from b in _db.BusDetails.ToList()
                                       select new {
                                           b.BusNo,
                                           b.BusName,
                                           b.RouteId }).ToList<object>();

            busdetails.Insert(0, new string[3] { "BusNo", "Bus Name", "RouteID" });

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < busdetails.Count; i++)
            {
                string[] b = (string[])busdetails[i];
                for (int j = 0; j < b.Length; j++)
                {
                    sb.Append(b[j] + ',');
                }
                sb.Append("\r\n");
            }
            return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "busdetails.csv");
        }
    }
}
