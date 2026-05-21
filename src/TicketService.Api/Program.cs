using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TicketService.Api.OpenApi;
using TicketService.Api.Security;
using TicketService.Application.Services;
using TicketService.Domain.Interfaces;
using TicketService.Infrastructure.Data;
using TicketService.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// custom OpenApi schema and document transformers

builder.Services.AddTicketOpenApi();

builder.Services.AddDbContext<TicketDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<TicketManager>();

// allows CORS needed for next.js frontend to call the API
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs", options =>
    {
        options.Title = "LMS Ticket API";
        options.Theme = ScalarTheme.Laserwave;
        options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();