namespace Blog.Pages;

public partial class Links
{
    private IList<LinkInfo>? LinksList;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        LinksList = await LinksTask;
    }
}
