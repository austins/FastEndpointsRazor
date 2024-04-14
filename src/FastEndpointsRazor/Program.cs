using FastEndpoints;
using FastEndpointsRazor;
using FastEndpointsRazor.Pages.Errors;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes.AddRange(DiscoveredTypes.All));
builder.Services.AddRazorComponents();

var app = builder.Build();

app.UseStatusCodePages(
    async context =>
    {
        // Show not found page on 404.
        if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            await new RazorComponentResult<NotFoundPage>().ExecuteAsync(context.HttpContext);
        }
    });

app.UseFastEndpoints();

await app.RunAsync();
