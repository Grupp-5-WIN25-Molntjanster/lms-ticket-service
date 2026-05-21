using Microsoft.AspNetCore.Mvc;
using TicketService.Application.DTOs;
using TicketService.Application.Services;

namespace TicketService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController(TicketManager ticketManager) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TicketResult>> Create(TicketRequest request)
    {
        var result = await ticketManager.CreateAsync(request);
        return result is null ? Problem("Failed to create ticket") : CreatedAtAction(nameof(Create), result);
    }
}
