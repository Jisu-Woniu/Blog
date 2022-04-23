namespace Blog.Pages;

public partial class PostDetail
{
    PostInfo Post { get; set; } = null!;
    string Content { get; set; } = "";

    [Parameter]
    public string UrlTitle { get; set; } = null!;

    string Title { get; set; } = "";
    DateTimeOffset PostTime { get; set; }
    bool _fetched;
    bool _notFound;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Dictionary<string, PostInfo> postsMap = await PostsMapTask;
        if (string.IsNullOrEmpty(UrlTitle) || !postsMap.ContainsKey(UrlTitle))
        {
            _notFound = true;
            return;
        }
        Post = postsMap[UrlTitle];
        string markdownText = await HttpClient.GetStringAsync($"posts-src/{UrlTitle}.md");
        Title = Post.Title;
        PostTime = Post.PostTime;
        Content = Markdig.Markdown.ToHtml(markdownText, Pipeline);
        _fetched = true;
    }
}
