namespace Blog.Shared;

public partial class InfoCard
{
    [Parameter]
    public Uri? Link { get; set; }

    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = null!;

    [Parameter]
    // [EditorRequired]
    public string Description { get; set; } = null!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    [EditorRequired]
    public Uri Icon { get; set; } = null!;

    bool _display = false;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        _display = true;
    }
}
