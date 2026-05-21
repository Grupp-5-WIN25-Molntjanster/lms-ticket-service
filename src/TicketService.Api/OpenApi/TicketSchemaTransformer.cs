using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using System.Text.Json.Nodes;
using TicketService.Application.DTOs;

namespace TicketService.Api.OpenApi;

public class TicketSchemaTransformer : IOpenApiSchemaTransformer
{
    public Task TransformAsync(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
    {
        var type = context.JsonTypeInfo.Type;
        if (type == typeof(TicketResult))
        {
            schema.Example = new JsonObject
            {
                ["id"] = 1,
                ["name"] = "Alice Smith",
                ["email"] = "alice@example.com",
                ["subject"] = "Login issue",
                ["message"] = "I cannot log in to my account.",
                ["createdAt"] = "2026-05-21T10:00:00Z",
                ["status"] = "Open"
            };
        }
        else if (type == typeof(TicketRequest))
        {
            schema.Example = new JsonObject
            {
                ["name"] = "Alice Smith",
                ["email"] = "alice@example.com",
                ["subject"] = "Login issue",
                ["message"] = "I cannot log in to my account."
            };
        }
        else if (type == typeof(TicketStatusRequest))
        {
            schema.Example = new JsonObject
            {
                ["status"] = "InProgress"
            };
        }
        return Task.CompletedTask;
    }
}