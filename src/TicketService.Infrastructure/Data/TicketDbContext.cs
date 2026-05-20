using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketService.Domain.Entities;

namespace TicketService.Infrastructure.Data;

public class TicketDbContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Tickets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Subject).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Message).HasMaxLength(4000).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(50).IsRequired();
        });
    }
}
