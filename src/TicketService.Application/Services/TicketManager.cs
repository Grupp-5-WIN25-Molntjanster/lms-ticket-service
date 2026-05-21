using TicketService.Application.DTOs;
using TicketService.Domain.Entities;
using TicketService.Domain.Interfaces;

namespace TicketService.Application.Services;

public class TicketManager(ITicketRepository repo)
{
    public async Task<List<TicketResult>> GetAllAsync()
    {
        var tickets = await repo.GetAllAsync();
        return tickets.Select(ToDto).ToList();
    }
    public async Task<TicketResult?> GetByIdAsync(int id)
    {
        var ticket = await repo.GetByIdAsync(id);
        return ticket is null ? null : ToDto(ticket);
    }
    public async Task<TicketResult?> CreateAsync(TicketRequest request)
    {
        var ticket = new Ticket(request.Name, request.Email, request.Subject, request.Message);
        var created = await repo.CreateAsync(ticket);
        return created is null ? null : ToDto(created);
    }
    public async Task<TicketResult?> UpdateAsync(int id, TicketRequest request)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null) return null;
        existing.UpdateDetails(request.Name, request.Email, request.Subject, request.Message);
        await repo.UpdateAsync(id, existing);
        return ToDto(existing);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await repo.DeleteAsync(id);
    }
    public async Task<TicketResult?> UpdateStatusAsync(int id, string newStatus)
    {
        var existing = await repo.GetByIdAsync(id);
        if (existing is null) return null;
        existing.UpdateStatus(newStatus);
        await repo.UpdateAsync(id, existing);
        return ToDto(existing);
    }
    static TicketResult ToDto(Ticket ticket) =>
        new TicketResult(ticket.Id, ticket.Name, ticket.Email, ticket.Subject, ticket.Message, ticket.CreatedAt, ticket.Status);
}