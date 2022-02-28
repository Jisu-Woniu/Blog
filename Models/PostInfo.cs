using System.Text.Json;
using System.Text.Json.Nodes;

namespace Blog.Models;

[Serializable]
public class PostInfo
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTimeOffset PostTime { get; set; }

    public static PostInfo? FromJson(JsonObject jsonInfo)
    {
        return jsonInfo.Deserialize<PostInfo>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
