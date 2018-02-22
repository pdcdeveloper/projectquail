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
        // Patterns use positive lookbehind and lazy modifier positive lookahead ("C# 5.0 In a Nutshell" by the Albahari brothers (p.998))
        const string basicItagPattern = @"itag=\d{1,3}";                // match "itag=ddd"   return "itag=ddd"


        // Retrieves the available download urls by decoding the video info dom for the 'contentId' to parse for itags.
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
            const string codecsPattern = "(?<=codecs=\x22.*?\x22).*";
            const string projectionPattern = "\x26projection_type=.*";
            const string clenPattern = @"\x26clen=\d*|clen=\d*";
            const string lmtPattern = @"\x26lmt=\d*|lmt=\d*";
            const string fallbackHostPattern = "fallback_host=.*\x26|fallback_Host=.*\x2C";
            const string itagPattern = @"\x26itag=\d{1,3}|itag=\d{1,3}";
            const string typePattern1 = "(?<=.*)type=.*\x22";
            const string typePattern2 = "\x26type=.*\x22";


            if (string.IsNullOrEmpty(contentId))
                return new VideoDownloadInfo(null, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content id.") , null);
            if (string.IsNullOrEmpty(contentTitle))
                return new VideoDownloadInfo(contentId, null, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content title."), null);
            if (string.IsNullOrEmpty(dom))
                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing dom."), null);

            // Decode pass 1
            dom = WebUtility.UrlDecode(dom);

            // Check for errors and specific messages.
            if (dom.Contains(responseError) || dom.Contains(responsePurchase))
            {
                if (dom.Contains(responseErrorCode))
                {
                    
                }
                else if (responseError.Contains(responsePurchase))
                {

                }
                else
                {
                    return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "The dom contains an error in the response."), null);
                }
            }
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
