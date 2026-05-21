using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.Application.DTOs;
using TicketService.Application.Services;

namespace TicketService.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class TicketsController(TicketManager ticketManager) : ControllerBase
{
    [HttpGet]
    [EndpointName("GetAllTickets")]
    [EndpointSummary("Get All Tickets")]
    [EndpointDescription("Returns a list of all support tickets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await ticketManager.GetAllAsync();
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    [EndpointName("GetTicketById")]
    [EndpointSummary("Get Ticket By Id")]
    [EndpointDescription("Returns a single support ticket by its Id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await ticketManager.GetByIdAsync(id);
        if (ticket is null) return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    [EndpointName("CreateTicket")]
    [EndpointSummary("Create a new Ticket")]
    [EndpointDescription("Creates a new support ticket and returns the created ticket")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(TicketRequest request)
    {
        var ticket = await ticketManager.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = ticket!.Id }, ticket);
    }

    [HttpPut("{id}")]
    [EndpointName("UpdateTicket")]
    [EndpointSummary("Update an existing Ticket")]
    [EndpointDescription("Updates an existing support ticket and returns the updated ticket")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, TicketRequest request)
    {
        var ticket = await ticketManager.UpdateAsync(id, request);
        if (ticket is null) return NotFound();
        return Ok(ticket);
    }

    [HttpPatch("{id}/status")]
    [EndpointName("UpdateTicketStatus")]
    [EndpointSummary("Update Ticket Status")]
    [EndpointDescription("Updates the status of an existing support ticket")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(int id, TicketStatusRequest request)
    {
        var ticket = await ticketManager.UpdateStatusAsync(id, request.Status);
        if (ticket is null) return NotFound();
        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    [EndpointName("DeleteTicket")]
    [EndpointSummary("Delete an existing Ticket")]
    [EndpointDescription("Deletes an existing support ticket")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await ticketManager.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}