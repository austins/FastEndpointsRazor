using FastEndpoints;
using FastEndpointsRazor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes.AddRange(DiscoveredTypes.All));
builder.Services.AddRazorComponents();

var app = builder.Build();
app.UseFastEndpoints();

await app.RunAsync();
