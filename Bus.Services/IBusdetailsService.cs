using Bus.Data;
using System.Collections.Generic;

namespace Bus.Services
{
    public interface IBusdetailsService
    {
        IEnumerable<BusDetails> GetAllBus();
        BusDetails GetBusbyID(int id);
        void AddBuss(BusDetails bus);
        void UpdateBus(BusDetails bus);
        void DeleteBus(int id);
        List<BusDetails> GetDataForHome();


    }
}
