using Bus.Data;
using Bus.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services
{
    public class TicketService : ITicketService
    {
        private IRepository<Ticket> _ticketRepository;
        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public void InsertTicket(Ticket ticket)
        {
            _ticketRepository.Create(ticket);
        }

    }
}
