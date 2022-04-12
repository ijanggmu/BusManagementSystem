using Bus.Services;
using Bus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bus.Web.Controllers
{
    public class BusDetailsController : Controller
    {
        private readonly IBusdetailsService _busservics;
        public BusDetailsController(IBusdetailsService busservices)
        {
            _busservics = busservices;
        }
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
                entity.routeName = items.routeName;
                busToView.Add(entity);
               
            }
            return View(busToView);
        }
    }
}
