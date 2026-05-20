using System;
using System.Collections.Generic;
using System.Text;
using TicketService.Domain.Entities;

namespace TicketService.Domain.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> CreateAsync(Ticket ticket);
}
