using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.Application.DTOs;

public record TicketResult
(
    int Id,
    string Name,
    string Email,
    string Subject,
    string Message,
    DateTime CreatedAt,
    string Status

);