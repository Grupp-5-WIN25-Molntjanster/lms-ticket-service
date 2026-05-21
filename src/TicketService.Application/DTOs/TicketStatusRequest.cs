using System.ComponentModel.DataAnnotations;
namespace TicketService.Application.DTOs;

public record TicketStatusRequest
(
    [Required(ErrorMessage = "Status is required")]
    string Status
);