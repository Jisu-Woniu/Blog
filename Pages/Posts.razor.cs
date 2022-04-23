namespace Blog.Pages;

public partial class Posts
{
    IList<PostInfo>? PostsList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        PostsList = await PostsListTask;
    }
}
