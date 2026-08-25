using ModelContextProtocol.Server;
using NetMiniMcp.Mcp.Tools;

namespace NetMiniMcp.Mcp;

public static class McpServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationMcp(this IServiceCollection services)
    {
        services
            .AddMcpServer()
            .WithHttpTransport()
            .WithTools<NumberTools>();

        return services;
    }
}
