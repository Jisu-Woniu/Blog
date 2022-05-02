namespace Blog.Pages;

public partial class Posts
{
    private IList<PostInfo>? PostsList { get; set; }

    override protected async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        PostsList = await PostsListTask;
    }
}
