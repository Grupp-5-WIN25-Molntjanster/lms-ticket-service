using System;
using System.Collections.Generic;
using System.Text;
using TicketService.Domain.Entities;

namespace TicketService.Domain.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task<Ticket?> CreateAsync(Ticket ticket);
    Task<Ticket?> UpdateAsync(int id, Ticket ticket);
    Task<bool> DeleteAsync(int id);
}