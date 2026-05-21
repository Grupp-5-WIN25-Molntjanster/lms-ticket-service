using System.ComponentModel.DataAnnotations;

namespace TicketService.Application.DTOs;

public record TicketRequest
(
    [Required(ErrorMessage = "Name is required")]
    string Name,

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    string Email,

    [Required(ErrorMessage = "Subject is required")]
    [MaxLength(100, ErrorMessage = "Subject cannot exceed 100 characters")]
    string Subject,

    [Required(ErrorMessage = "Message is required")]
    [MaxLength(1000, ErrorMessage = "Message cannot exceed 1000 characters")]
    string Message
);