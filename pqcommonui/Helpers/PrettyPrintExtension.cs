using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace pqcommonui.Helpers
{
    // Provides glorified formatting for numbers returned by Google.Apis.YouTube.v3.
    public static class PrettyPrintExtension
    {
        const string Epoch = "January 1, 1970";
        const string NoValueIndicator = "\xC4\xC4"; // double em dash
        const string LongDateFormatPattern = "MMMM d, yyyy";
        const string CommaDelineatedPattern = "###,###,###,###";
        const string DotDelineatedPattern = "###.###.###.###";
        const string SpaceDelineatedPattern = "### ### ### ###";

        // Duration format.
        public static string ColonDelineatedTimeFormat (this TimeSpan time)
        {
            if (time.Hours > 0 && time.Hours < 24)
                return time.ToString(@"hh\:mm\:ss");
            else if (time.Hours == 0)
                return time.ToString(@"mm\:ss");
            else
                return NoValueIndicator;
        }

        // Use cases:
        //      Channel.Statistics.CommentCount
        //      Channel.Statistics.SubscriberCount
        //      Channel.Statistics.ViewCount
        //      Channel.Statistics.VideoCount
        //      Video.Statistics.ViewCount
        //      Video.Statistics.LikeCount
        //      Video.Statistics.DislikeCount
        //      Video.Statistics.CommentCount
        public static string DelineateNumber(this ulong? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            return number.Value.ToString(SpaceDelineatedPattern);
        }

        // Use cases:
        //      Playlist.ContentDetails.ItemCount
        //      Comment.Snippet.LikeCount
        //      CommentThread.Snippet.TopLevelComment.Snippet.LikeCount
        //      CommentThread.Snippet.TotalReplyCount
        public static string DelineateNumber(this long? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            return number.Value.ToString(SpaceDelineatedPattern);
        }

        public static string DelineateNumber(this uint? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(SpaceDelineatedPattern);
        }

        public static string DelineateNumber(this int? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(SpaceDelineatedPattern);
        }

        public static string DelineateNumber(this ushort? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(SpaceDelineatedPattern);
        }

        public static string DelineateNumber(this short? number)
        {
            if (!number.HasValue || number.Value == 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(SpaceDelineatedPattern);
        }

        // Google.Apis.YouTube.v3.Data.VideoContentDetails
        // The length of the video. The tag value is an ISO 8601 duration in the format
        // PT#M#S, in which the latters PT indicate that the value specifies a period of
        // time, and the ltters M and S refer to length in mutes and seconds, respectively.
        // The # characters preceding the M and S letters are both integers that specify
        // the number of minutes (or seconds) of the video. For example, a value of PT15M1S
        // indicates that the video is 15 minutes and 51 seconds long.
        // Why are there so many typos?  I'm pretty sure I copy-pasta the comment straight from Google's YouTube api.
        public static string DecodeISO8601Duration(this string duration)
        {
            if (string.IsNullOrEmpty(duration))
                return @"\xC4\:\xC4";   // em dashes separated by a colon

            if (!Regex.Match(duration, "PT.*").Success)
                return @"\xC4\:\xC4";

            TimeSpan time = XmlConvert.ToTimeSpan(duration);
            return ColonDelineatedTimeFormat(time);
        }

        // Use cases:
        //      Any PublishedAt property in Google.Apis.YouTube.v3.
        public static string LongDateFormat(this DateTime? date)
        {
            if (!date.HasValue)
                return Epoch;
            return date.Value.ToString(LongDateFormatPattern);
        }

        public static DateTime? ParseDate(this string date)
        {
            if (!string.IsNullOrEmpty(date))
                if (DateTime.TryParse(date, out DateTime d))
                    return d;
            return new DateTime(1970, 1, 1);    // Epoch
        }
    }
}
