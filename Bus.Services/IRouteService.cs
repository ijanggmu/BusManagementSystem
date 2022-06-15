using Bus.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services
{
    public interface IRouteService
    {
        IEnumerable<Route> GetAllRoute();
        Route GetRouteById(int id);

        void InsertRoute(Route route);
        void UpdateRoute(Route route);
        void DeleteRoute(int id);
        
    }
}
