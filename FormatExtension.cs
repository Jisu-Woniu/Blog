namespace Blog;

public static class FormatExtension
{
    public static string SiteFormat(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.LocalDateTime.ToString("yyyy 年 MM 月 dd 日 HH:mm");
    }
}
