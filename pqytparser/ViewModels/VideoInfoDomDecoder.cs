using pqytparser.Interfaces;
using pqytparser.Models;
using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace pqytparser.ViewModels
{
    public class VideoInfoDomDecoder : IVideoInfoDomDecoder
    {
        // Patterns use positive lookbehind and lazy modifier positive lookahead ("C# 5.0 In a Nutshell" by the Albahari brothers (p.998))
        const string basicItagPattern = @"itag=\d{1,3}";                // match "itag=ddd"   return "itag=ddd"


        // Retrieves the available download urls by decoding the video info dom for the 'contentId' to parse for itags.
        public VideoDownloadInfo GetVideoDownloadInfo(string contentId, string dom)
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


        // Parses 'input' for the first instance of an query parameter "itag".
        bool TryParseUrlForItag(string input, out string output)
        {
            const string itagPattern1 = @"(?<=\x3F)itag=\d{1,3}?(?=\x26)";  // match "?itag=ddd&" return "itag=ddd"
            const string itagPattern2 = @"(?<=\x26)itag=\d{1,3}?(?=\x26)";  // match "&itag=ddd&" return "itag=ddd"
            const string itagPattern3 = @"(?<=\x26)itag=\d{1,3}";           // match "&itag=ddd"  return "itag=ddd"
        }


        // Safely cast from a string to 'Resources.MediaQualityEnum'.  Relies on the int value of each enum member within 'MediaQualityEnum'.
        MediaQualityEnum MaptoItag(string input)
        {
            const string itagValuePattern = @"(?<=itag=)\d{1,3}";           // match "itag=ddd"   return "ddd"
        }
    }
}
