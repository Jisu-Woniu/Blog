namespace Blog.Pages;

public partial class Links
{
    private IList<LinkInfo>? LinksList;

    override protected async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        LinksList = await LinksTask;
    }
}
