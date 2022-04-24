namespace Blog.Pages;

public partial class Links
{
    private IList<LinkInfo>? LinksList;

    override protected async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        LinksList = await LinksTask;
    }
}
