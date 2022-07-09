using Bus.Data;
using System.Collections.Generic;
using System.Linq;

namespace Bus.Services.Contracts
{
    public interface IRouteService
    {
        IEnumerable<Route> GetAllRoute();
        Route GetRouteById(int id);

        void InsertRoute(Route route);
        void UpdateRoute(Route route);
        void DeleteRoute(int id);
        List<Route> GetIndexData();

    }
}
