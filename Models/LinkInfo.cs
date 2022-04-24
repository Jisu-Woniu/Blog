namespace Blog.Models;

public class LinkInfo
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Uri Link { get; set; } = null!;
    public Uri Icon { get; set; } = null!;
}
