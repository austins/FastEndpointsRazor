namespace FastEndpointsRazor.Pages.Home;

public sealed class TestPageEndpoint : PageEndpointWithoutRequest<TestPage>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/");
    }

    protected override Task HandleAsync(CancellationToken ct)
    {
        return SendPageAsync(new Dictionary<string, object?>
        {
            { nameof(TestPage.TestParameter), "Hello, world! This is text from the endpoint handler." }
        });
    }
}
