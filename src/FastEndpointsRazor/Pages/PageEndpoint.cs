using FastEndpoints;
using FastEndpointsRazor.Pages.Errors;
using FastEndpointsRazor.Razor;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsRazor.Pages;

public abstract class PageEndpoint<TRequest, TPage> : Endpoint<TRequest, RazorComponentResult<TPage>>
    where TRequest : notnull
    where TPage : Component
{
    [NotImplemented]
    public sealed override Task<RazorComponentResult<TPage>> ExecuteAsync(TRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    protected Task SendPageAsync(IReadOnlyDictionary<string, object?>? parameters = null)
    {
        return SendPageAsync<TPage>(parameters, StatusCodes.Status200OK);
    }

    protected new Task SendNotFoundAsync(CancellationToken cancellation = default)
    {
        return SendPageAsync<NotFoundPage>(null, StatusCodes.Status404NotFound);
    }

    private Task SendPageAsync<TTargetPage>(IReadOnlyDictionary<string, object?>? parameters, int statusCode)
        where TTargetPage : Component
    {
        HttpContext.MarkResponseStart();
        HttpContext.Response.StatusCode = statusCode;

        return new RazorComponentResult<TTargetPage>(parameters ?? new Dictionary<string, object?>()).ExecuteAsync(
            HttpContext);
    }
}

public abstract class PageEndpointWithoutRequest<TPage> : PageEndpoint<EmptyRequest, TPage>
    where TPage : Component
{
    public sealed override Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        return HandleAsync(ct);
    }

    [NotImplemented]
    protected virtual Task HandleAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
