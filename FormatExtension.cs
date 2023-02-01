using Humanizer;

namespace Blog;

public static class FormatExtension
{
    public static string ToRelativeTime(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.LocalDateTime.Humanize();
    }

    public static string ToAbsoluteTime(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.LocalDateTime.ToString("yyyy 年 MM 月 dd 日 HH:mm");
    }
}
