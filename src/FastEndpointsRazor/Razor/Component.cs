using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace FastEndpointsRazor.Razor;

public class Component : IComponent
{
    private readonly RenderFragment _renderFragment;

    private RenderHandle _renderHandle;

    public Component()
    {
        _renderFragment = BuildRenderTree;
    }

    public void Attach(RenderHandle renderHandle)
    {
        _renderHandle = renderHandle;
    }

    public Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        _renderHandle.Render(_renderFragment);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Renders the component to the supplied <see cref="RenderTreeBuilder" />.
    /// </summary>
    /// <param name="builder">A <see cref="RenderTreeBuilder" /> that will receive the render output.</param>
    protected virtual void BuildRenderTree(RenderTreeBuilder builder)
    {
        // Developers can either override this method in derived classes, or can use Razor
        // syntax to define a derived class and have the compiler generate the method.

        // Other code within this class should *not* invoke BuildRenderTree directly,
        // but instead should invoke the _renderFragment field.
    }
}
