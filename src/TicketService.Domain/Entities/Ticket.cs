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
    public string Status { get; set; } = null!;

    private Ticket() { }

    public Ticket(string name, string email, string subject, string message)
    {
        SetName(name);
        SetEmail(email);
        SetSubject(subject);
        SetMessage(message);
        CreatedAt = DateTime.UtcNow;
        Status = "Open";
    }
    public void UpdateDetails(string name, string email, string subject, string message)
    {
        SetName(name);
        SetEmail(email);
        SetSubject(subject);
        SetMessage(message);
    }
    public void UpdateStatus(string newStatus)
    {
        if (string.IsNullOrWhiteSpace(newStatus))
            throw new ArgumentException("Status cannot be empty.", nameof(newStatus));
        if (newStatus.Length > 50)
            throw new ArgumentException("Status cannot exceed 50 characters.", nameof(newStatus));
        var allowed = new[] { "Open", "InProgress", "Resolved", "Closed" };
        if (!allowed.Contains(newStatus))
            throw new ArgumentException($"Status must be one of: {string.Join(", ", allowed)}", nameof(newStatus));
        Status = newStatus;
    }
    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        if (name.Length > 50)
            throw new ArgumentException("Name cannot exceed 50 characters.", nameof(name));
        Name = name;
    }
    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        if (email.Length > 50)
            throw new ArgumentException("Email cannot exceed 50 characters.", nameof(email));
        Email = email;
    }
    private void SetSubject(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException("Subject cannot be empty.", nameof(subject));
        if (subject.Length > 100)
            throw new ArgumentException("Subject cannot exceed 100 characters.", nameof(subject));
        Subject = subject;
    }
    private void SetMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Message cannot be empty.", nameof(message));
        if (message.Length > 4000)
            throw new ArgumentException("Message cannot exceed 4000 characters.", nameof(message));
        Message = message;
    }
}