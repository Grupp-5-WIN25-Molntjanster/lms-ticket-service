using System.ComponentModel.DataAnnotations;

namespace TicketService.Application.DTOs;

public record TicketRequest
(
    [Required]
    string Name,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [MaxLength(100)]
    string Subject,

    [Required]
    [MaxLength(1000)]
    string Message
);