using Bus.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void InsertTicket(Ticket ticket);
    }
}
