using pqytparser.Interfaces;
using pqytparser.Models;
using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace pqytparser.ViewModels
{
    public class VideoInfoDomDecoder : IVideoInfoDomDecoder
    {
        // Patterns use positive lookbehind and lazy modifier positive lookahead ("C# 5.0 In a Nutshell" by the Albahari brothers (p.998)).
        const string basicItagPattern = @"itag=\d{1,3}";                // match "itag=ddd"   return "itag=ddd"


        // Retrieves the available download urls by decoding the video info DOM for the 'contentId' to parse for itags.
        public VideoDownloadInfo GetVideoDownloadInfo(string contentId, string contentTitle, string dom)
        {
            const string responseError = "&errorcode";
            const string responseErrorCode = "&errorcode=150";
            const string responsePurchase = "&requires_purchase";
            const string https = "https";
            const string mime = "mime=";
            const string ytimg = "ytimg";
            const string url = "url=";

            const string streamMapPattern = "(?<=url_encoded_fmt_stream_map=).*";


            if (string.IsNullOrEmpty(contentId))
                return new VideoDownloadInfo(null, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content id.") , null);
            if (string.IsNullOrEmpty(contentTitle))
                return new VideoDownloadInfo(contentId, null, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content title."), null);
            if (string.IsNullOrEmpty(dom))
                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing dom."), null);

            // Decode pass 1.
            dom = WebUtility.UrlDecode(dom);

            // Check for errors and specific messages.
            if (dom.Contains(responseError) || dom.Contains(responsePurchase))
            {
                string errorMessage = string.Empty;
                VideoAvailabilityEnum errorStatus = VideoAvailabilityEnum.NotAvailable;

                if (dom.Contains(responseErrorCode))
                {
                    errorMessage = "YouTube video info response contains errorcode 150.";
                    errorStatus = VideoAvailabilityEnum.ErrorCode;
                }
                else if (responseError.Contains(responsePurchase))
                {
                    errorMessage = "YouTube content requires purchase.";
                    errorStatus = VideoAvailabilityEnum.RequiresPurchase;
                }
                else
                {
                    errorMessage = "The dom contains an error in the response.";
                    errorStatus = VideoAvailabilityEnum.ErrorCode;
                }

                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(errorStatus, errorMessage), null);
            }

            // Get everything after "url_encoded_fmt_stream_map=".
            dom = Regex.Match(dom, streamMapPattern).Value;

            // Decode pass 2.
            dom = WebUtility.UrlDecode(dom);

            // Split.
            string[] responseUrls = Regex.Split(dom, url);

            // Clean up the URLs.

        }


        // Retrieves the DOM for the given 'contentId' using YouTube's video info query api.
        public async Task<string> GetVideoInfoDomAsync(string contentId)
        {
            const string videoInfoBaseUrl = "https://www.youtube.com/get_video_info?video_id=";

            Uri videoInfoUri = new Uri(videoInfoBaseUrl + contentId, UriKind.Absolute);
            string response = string.Empty;
            using (HttpClient client = new HttpClient())
                response = await client.GetStringAsync(videoInfoUri);
            return response;
        }


        // Cleans up a URL by removing unnecessary query parameters.
        // <see cref="https://stackoverflow.com/questions/73883/string-vs-stringbuilder"/>
        // <see cref="https://support.microsoft.com/en-us/help/306822/how-to-improve-string-concatenation-performance-in-visual-c"/>
        string RemoveQueryParameters(string input)
        {
            const string codecsPattern = "(?<=codecs=\x22.*?\x22).*";
            const string projectionPattern = "\x26projection_type=.*";
            const string clenPattern = @"\x26clen=\d*|clen=\d*";
            const string lmtPattern = @"\x26lmt=\d*|lmt=\d*";
            const string fallbackHostPattern = "fallback_host=.*\x26|fallback_Host=.*\x2C";
            const string itagPattern = @"\x26itag=\d{1,3}|itag=\d{1,3}";
            const string typePattern1 = "(?<=.*)type=.*\x22";
            const string typePattern2 = "\x26type=.*\x22";


            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string url = new string(input.ToCharArray());

            // Decode.  By the time the 'url' gets here, this should be pass 3.
            url = WebUtility.UrlDecode(url);

            // Remove everything after the "codecs" parameter.
            Match mcodecsp = Regex.Match(url, codecsPattern);
            if (mcodecsp.Success)
                url = url.Remove(mcodecsp.Index, mcodecsp.Length);

            // Remove "projection_type" parameter and everything after it.
            Match mprojectionp = Regex.Match(url, projectionPattern);
            if (mprojectionp.Success)
                url = url.Remove(mprojectionp.Index, mprojectionp.Length);

            // Remove the trailing "clen" parameter.
            MatchCollection mclenp = Regex.Matches(url, clenPattern, RegexOptions.RightToLeft);
            if (mclenp.Count > 1)
                url = url.Remove(mclenp[0].Index, mclenp[0].Length);

            // Remove the trailing "lmt" pattern.
            MatchCollection mlmtp = Regex.Matches(url, lmtPattern, RegexOptions.RightToLeft);
            if (mlmtp.Count > 1)
                url = url.Remove(mlmtp[0].Index, mlmtp[0].Length);

            // Remove "fallback_host" parameter.
            Match mfallbackhostp = Regex.Match(url, fallbackHostPattern);
            if (mfallbackhostp.Success)
                url = url.Remove(mfallbackhostp.Index, mfallbackhostp.Length);

            // Remove trailing "itag" parameter.  Sometimes there's multiple itags within a url -- there can only be one.
            MatchCollection mitagp = Regex.Matches(url, itagPattern, RegexOptions.RightToLeft);
            if (mitagp.Count > 1)
                url = url.Remove(mitagp[0].Index, mitagp[0].Length);

            // Sometimes the "&" infront of the "type" parameter is no longer there and it must be manually re-added.
            Match mtypep1 = Regex.Match(url, typePattern1);
            if (mtypep1.Success)
            {
                Match mtypep2 = Regex.Match(url, typePattern2);
                if (!mtypep2.Success)
                {
                    // Remove the match first.
                    url = url.Remove(mtypep1.Index, mtypep1.Length);
                    // Append an "&" followed by the "type" parameter from the match.
                    url = url.Insert(mtypep1.Index, '\x26' + mtypep1.Value);
                }
            }

            return url;
        }


        // Parses 'input' for the first instance of an query parameter "itag=ddd".
        bool TryParseUrlForItag(string input, out string output)
        {
            const string itagPattern1 = @"(?<=\x3F)itag=\d{1,3}?(?=\x26)";  // match "?itag=ddd&" return "itag=ddd"
            const string itagPattern2 = @"(?<=\x26)itag=\d{1,3}?(?=\x26)";  // match "&itag=ddd&" return "itag=ddd"
            const string itagPattern3 = @"(?<=\x26)itag=\d{1,3}";           // match "&itag=ddd"  return "itag=ddd"


            output = null;

            // Match for "itag=ddd".  Uses multiple regex patterns which range from fine grained to coarse search.
            Match match = Regex.Match(input, itagPattern1);
            if (!match.Success)
                if (!((match = Regex.Match(input, itagPattern2)).Success))
                    if (!((match = Regex.Match(input, itagPattern3)).Success))
                        if (!((match = Regex.Match(input, basicItagPattern)).Success))
                            return false;

            // Verify the match.
            Match verify = Regex.Match(match.Value, basicItagPattern);
            if (!verify.Success)
                return false;

            output = match.Value;
            return true;
        }


        // Safely cast from a string to 'Resources.MediaQualityEnum'.  Relies on the int value of each enum member within 'Resources.MediaQualityEnum'.
        MediaQualityEnum MapToItag(string input)
        {
            const string itagEnumValuePattern = @"(?<=itag=)\d{1,3}";           // match "itag=ddd"   return "ddd"

            // Check if there is an itag before continuing using finer regex pattern.
            Match match1 = Regex.Match(input, basicItagPattern);
            if (!match1.Success || (match1.Success && match1.Value != input))
                return MediaQualityEnum.Unknown;

            // Get only the enum value of the itag.
            Match match2 = Regex.Match(input, itagEnumValuePattern);
            if (!match2.Success)
                return MediaQualityEnum.Unknown;
            if (!int.TryParse(match2.Value, out int value))
                return MediaQualityEnum.Unknown;

            // Iterate through 'Resources.MediaQualityEnum'.
            // <see cref="http://stackoverflow.com/questions/105372/how-do-i-enumerate-an-enum"/>
            foreach (MediaQualityEnum itag in Enum.GetValues(typeof(MediaQualityEnum)))
                if ((int)itag == value)
                    return itag;
            return MediaQualityEnum.Unknown;
        }
    }
}
