using NetMiniMcp.Mcp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationMcp();

var app = builder.Build();

app.MapApplicationEndpoints();

app.Run();
