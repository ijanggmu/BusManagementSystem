using Bus.Data;
using Bus.Repo;
using Bus.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bus.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRepository<Route> _routeRepository;
        private readonly ApplicationDbContext _db;
        public RouteService(IRepository<Route> routeRepository, ApplicationDbContext db)
        {
            _routeRepository = routeRepository;
            _db = db;
        }
        public void DeleteRoute(int id)
        {
            Route route = GetRouteById(id);
            _routeRepository.Delete(route);
            _routeRepository.SaveChanges();
        }

        public IEnumerable<Route> GetAllRoute()
        {
            return _routeRepository.GetAll();
        }


        public Route GetRouteById(int id)
        {
            return _routeRepository.GetById(id);
        }

        public void InsertRoute(Route route)
        {
            _routeRepository.Create(route);
        }

        public void UpdateRoute(Route route)
        {
            _routeRepository.Update(route);
        }
        public List<Route> GetIndexData(){
            var user = _db.Routes.Include(x => x.BusDetails).ToList();
            
           
        //var userView = (from r in _routeRepository
        //                join b in _db.BusDetails
        //                on r.Id equals b.RouteId into n
        //                from m in n.DefaultIfEmpty()
        //                select new RouteViewModel
        //                {
        //                    Id = r.Id,
        //                    RouteName = r.RouteName,
        //                    NumberOfStops = r.NumberOfStops,
        //                    BusCount = r.BusCount,
        //                    PermitedBus = r.BusDetails.Count(),
        //                    RemainingBusPermit = r.BusCount - r.BusDetails.Count(),
        //                    RouteMapLink = r.RouteMapLink,
        //                }).Distinct();
            return user;
                                        }
    }
}
