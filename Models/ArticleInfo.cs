using System.Text.Json;
using System.Text.Json.Nodes;

namespace Blog.Models;

[Serializable]
public class ArticleInfo
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTimeOffset PostTime { get; set; }

    public static ArticleInfo? FromJson(JsonObject jsonInfo)
    {
        return jsonInfo.Deserialize<ArticleInfo>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
