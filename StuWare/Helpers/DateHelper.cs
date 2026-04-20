using System;

namespace StuWare.Helpers
{
    public static class DateHelper
    {
        public static string GetTimeAgo(DateTime dateTime)
        {
            if (dateTime == default || dateTime.Year < 1900)
                return "Just now";

            var now = DateTime.Now;
            if (dateTime > now)
                return "Just now";

            var span = now - dateTime;

            if (span.TotalMinutes < 1)
                return "Just now";

            var minutes = (int)Math.Floor(span.TotalMinutes);
            if (span.TotalHours < 1)
                return minutes <= 1 ? "1 minute ago" : $"{minutes} minutes ago";

            var hours = (int)Math.Floor(span.TotalHours);
            if (span.TotalDays < 1)
                return hours <= 1 ? "1 hour ago" : $"{hours} hours ago";

            var days = (int)Math.Floor(span.TotalDays);
            if (days < 7)
                return days <= 1 ? "1 day ago" : $"{days} days ago";

            if (span.TotalDays < 30)
            {
                var weeks = Math.Max(1, days / 7);
                return weeks == 1 ? "1 week ago" : $"{weeks} weeks ago";
            }

            if (span.TotalDays < 365)
            {
                var months = Math.Max(1, days / 30);
                return months == 1 ? "1 month ago" : $"{months} months ago";
            }

            var years = Math.Max(1, days / 365);
            return years == 1 ? "1 year ago" : $"{years} years ago";
        }
    }
}
