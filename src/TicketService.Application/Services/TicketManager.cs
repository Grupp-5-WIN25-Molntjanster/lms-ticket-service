using TicketService.Application.DTOs;
using TicketService.Domain.Entities;
using TicketService.Domain.Interfaces;

namespace TicketService.Application.Services;

public class TicketManager(ITicketRepository repo)
{
    public async Task<TicketResult?> CreateAsync(TicketRequest request)
    {
        var ticket = new Ticket(request.Name, request.Email, request.Subject, request.Message);
        var created = await repo.CreateAsync(ticket);
        return created is null ? null : ToDto(created);
    }

    static TicketResult ToDto(Ticket ticket) =>
        new TicketResult(ticket.Id, ticket.Name, ticket.Email, ticket.Subject, ticket.Message, ticket.CreatedAt, ticket.Status);
}
