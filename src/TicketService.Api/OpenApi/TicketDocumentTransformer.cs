using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace TicketService.Api.OpenApi;

public class TicketDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Info = new OpenApiInfo()
        {
            Title = "Ticket API",
            Version = "v1",
            Description = """
            An API for managing support tickets,
            allowing clients to perform CRUD operations on tickets.
            """,
            Contact = new OpenApiContact()
            {
                Name = "Ticket API Support",
                Url = new Uri("https://github.com/alnils"),
            }
        };
        return Task.CompletedTask;
    }
}