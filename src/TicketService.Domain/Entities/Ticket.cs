using System;
using System.Collections.Generic;
using System.Text;

namespace TicketService.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = "Open";


    private Ticket() { }


    public Ticket(string name, string email, string subject, string message)
    {
        Name = name;
        Email = email;
        Subject = subject;
        Message = message;
        CreatedAt = DateTime.UtcNow;
    }
}