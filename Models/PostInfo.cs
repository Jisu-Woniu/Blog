using System.Text.Json;
using System.Text.Json.Nodes;

namespace Blog.Models;

[Serializable]
public class PostInfo
{
    public string Title { get; set; } = null!;
    public string UrlTitle { get; set; } = null!;
    public DateTimeOffset PostTime { get; set; }
    public RepostInfo? Repost { get; set; }

    public class RepostInfo
    {
        public string? OriginalAuthor { get; set; }
        public Uri OriginalUrl { get; set; } = null!;
        public string? License { get; set; }
        public Uri? LicenseUrl { get; set; }
    }

    public static PostInfo? FromJson(JsonObject jsonInfo)
    {
        return jsonInfo.Deserialize<PostInfo>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
