using Bus.Data;
using Bus.Repo;
using Bus.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bus.Services
{
    public class BusDetailsService : IBusdetailsService
    {
        private readonly IRepository<BusDetails> _busRepo;
        private readonly ApplicationDbContext _db;
        public BusDetailsService(IRepository<BusDetails> busRepo,ApplicationDbContext db)
        {
            _db = db;
            _busRepo = busRepo;
        }

        public void AddBuss(BusDetails bus)
        {

            _busRepo.Create(bus);
        }

        public void DeleteBus(int id)
        {
            var bus = _busRepo.GetById(id);
            _busRepo.Delete(bus);
            _busRepo.SaveChanges();
        }

        public IEnumerable<BusDetails> GetAllBus()
        {
            return _busRepo.GetAll().Where(x=>x.isDisable==false).ToList();
        }

        public BusDetails GetBusbyID(int id)
        {
            return _busRepo.GetById(id);
        }

        public void UpdateBus(BusDetails bus)
        {
            _busRepo.Update(bus);
        }
        public List<BusDetails> GetDataForHome()
        {
            var newdata = _db.BusDetails.Include(x => x.Route).Where(x => x.isDisable == false).ToList();
            
            return newdata;
        }
    }
}
