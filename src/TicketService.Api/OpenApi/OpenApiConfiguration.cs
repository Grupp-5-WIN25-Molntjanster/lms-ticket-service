namespace TicketService.Api.OpenApi;

public static class OpenApiConfiguration
{
    public static IServiceCollection AddTicketOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer<TicketDocumentTransformer>();
            options.AddSchemaTransformer<TicketSchemaTransformer>();
        });
        return services;
    }
}