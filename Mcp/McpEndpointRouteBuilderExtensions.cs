namespace NetMiniMcp.Mcp;

public static class McpEndpointRouteBuilderExtensions
{
    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
        app.MapMcp("/mcp");

        return app;
    }
}
