using Bus.Data;
using Bus.Repo;
using System;
using System.Collections.Generic;

namespace Bus.Services
{
    public class RouteService : IRouteService
    {
        private IRepository<Route> _routeRepository;
        public RouteService(IRepository<Route> routeRepository)
        {
            _routeRepository = routeRepository;
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

        public void InserRoute(Route route)
        {
            _routeRepository.Create(route);
        }

        public void UpdaetRoute(Route route)
        {
            _routeRepository.Update(route);
        }
    }
}
