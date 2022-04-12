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

        void InserRoute(Route route);
        void UpdaetRoute(Route route);
        void DeleteRoute(int id);
    }
}
