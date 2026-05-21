using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TicketService.Domain.Entities;
using TicketService.Domain.Interfaces;
using TicketService.Infrastructure.Data;

namespace TicketService.Infrastructure.Repositories;

public class TicketRepository(TicketDbContext context) : ITicketRepository
{
    public async Task<List<Ticket>> GetAllAsync()
    {
        return await context.Tickets.OrderByDescending(t => t.CreatedAt).ToListAsync();
    }
    public Task<Ticket?> GetByIdAsync(int id)
    {
        return context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
    }
    public async Task<Ticket?> CreateAsync(Ticket ticket)
    {
        context.Tickets.Add(ticket);
        await context.SaveChangesAsync();
        return ticket;
    }
    public async Task<Ticket?> UpdateAsync(int id, Ticket ticket)
    {
        var existing = await context.Tickets.FindAsync(id);
        if (existing is null) return null;
        context.Entry(existing).CurrentValues.SetValues(ticket);
        await context.SaveChangesAsync();
        return existing;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await context.Tickets.FindAsync(id);
        if (ticket is null) return false;
        context.Tickets.Remove(ticket);
        await context.SaveChangesAsync();
        return true;
    }
}