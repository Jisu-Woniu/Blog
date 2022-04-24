namespace Blog.Pages;

public partial class Posts
{
    private IList<PostInfo>? PostsList { get; set; }

    override protected async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        PostsList = await PostsListTask;
    }
}
