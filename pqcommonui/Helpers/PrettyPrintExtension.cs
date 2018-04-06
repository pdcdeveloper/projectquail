using System;
using System.Text.RegularExpressions;
using System.Xml;
using static pqlib.Characters.Ascii;

namespace pqcommonui.Helpers
{
    // Provides glorified formatting for numbers returned by Google.Apis.YouTube.v3.
    public static class PrettyPrintExtension
    {
        const string _epoch = "January 1, 1970";
        const string _longDateFormatPattern = "MMMM d, yyyy";
        const string _commaDelineatedPattern = "###,###,###,###";
        const string _dotDelineatedPattern = "###.###.###.###";
        const string _spaceDelineatedPattern = "### ### ### ###";

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
        public static string DelineatePositiveNumber(this ulong? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            return number.Value.ToString(_spaceDelineatedPattern);
        }

        // Use cases:
        //      Playlist.ContentDetails.ItemCount
        //      Comment.Snippet.LikeCount
        //      CommentThread.Snippet.TopLevelComment.Snippet.LikeCount
        //      CommentThread.Snippet.TotalReplyCount
        public static string DelineatePositiveNumber(this long? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            return number.Value.ToString(_spaceDelineatedPattern);
        }

        public static string DelineatePositiveNumber(this uint? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(_spaceDelineatedPattern);
        }

        public static string DelineatePositiveNumber(this int? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(_spaceDelineatedPattern);
        }

        public static string DelineatePositiveNumber(this ushort? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(_spaceDelineatedPattern);
        }

        public static string DelineatePositiveNumber(this short? number)
        {
            if (!number.HasValue || number.Value <= 0)
                return NoValueIndicator;
            else
                return number.Value.ToString(_spaceDelineatedPattern);
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
            // Regex could be interwoven with if statements to check the validity of each time value.  For another day...
            if (string.IsNullOrEmpty(duration) || !Regex.Match(duration, @"(^PT\d{1,2}H$)|(^PT\d{1,2}M$)|(^PT\d{1,2}S$)|(^PT\d{1,2}H\d{1,2}M$)|(^PT\d{1,2}H\d{1,2}S$)|(^PT\d{1,2}M\d{1,2}S$)|(^PT\d{1,2}H\d{1,2}M\d{1,2}S$)", RegexOptions.IgnoreCase).Success)
                return EmDash + ":" + EmDash;

            TimeSpan time = XmlConvert.ToTimeSpan(duration.ToUpper());
            return ColonDelineatedTimeFormat(time);
        }

        // Use cases:
        //      Any PublishedAt property in Google.Apis.YouTube.v3.
        public static string LongDateFormat(this DateTime? date)
        {
            if (!date.HasValue)
                return _epoch;
            return date.Value.ToString(_longDateFormatPattern);
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
