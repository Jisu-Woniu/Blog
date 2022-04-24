namespace Blog.Pages;

public partial class PostDetail
{
    private PostInfo Post { get; set; } = null!;
    private string Content { get; set; } = "";

    [Parameter]
    public string UrlTitle { get; set; } = null!;

    private string Title { get; set; } = "";
    private DateTimeOffset PostTime { get; set; }

    private bool _fetched;
    private bool _notFound;

    override protected async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        //Dictionary<string, PostInfo> postsMap = await PostsMapTask;
        IList<PostInfo> postsList = await PostsListTask;

        if (
            !string.IsNullOrEmpty(UrlTitle)
            && postsList.FirstOrDefault(post => post.UrlTitle == UrlTitle) is PostInfo post
        )
        {
            Post = post;
        }
        else
        {
            _notFound = true;
            return;
        }

        string markdownText = await HttpClient.GetStringAsync($"posts-src/{UrlTitle}.md");
        Title = Post.Title;
        PostTime = Post.PostTime;
        Content = Markdig.Markdown.ToHtml(markdownText, Pipeline);
        _fetched = true;
    }
}
