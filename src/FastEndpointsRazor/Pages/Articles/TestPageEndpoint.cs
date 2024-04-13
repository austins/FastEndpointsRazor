namespace FastEndpointsRazor.Pages.Articles;

public sealed class TestPageEndpoint : PageEndpointWithoutRequest<TestPage>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/");
    }

    protected override Task HandleAsync(CancellationToken ct)
    {
        return SendPageAsync(new Dictionary<string, object?> { { "TestParameter", "Hello, world!" } });
    }
}
