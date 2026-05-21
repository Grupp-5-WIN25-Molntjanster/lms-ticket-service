using System;
using System.Collections.Generic;
using System.Text;
using TicketService.Domain.Entities;
using TicketService.Domain.Interfaces;
using TicketService.Infrastructure.Data;

namespace TicketService.Infrastructure.Repositories;

public class TicketRepository(TicketDbContext context) : ITicketRepository
{
    public async Task<Ticket?> CreateAsync(Ticket ticket)
    {
        context.Tickets.Add(ticket);
        var saved = await context.SaveChangesAsync();
        return saved > 0 ? ticket : null;
    }
}
