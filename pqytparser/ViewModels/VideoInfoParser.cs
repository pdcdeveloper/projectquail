using pqytparser.Interfaces;
using pqytparser.Models;
using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqytparser.ViewModels
{
    public class VideoInfoParser : IVideoInfoParser
    {
        const string VideoInfoBaseUrl = "https://www.youtube.com/get_video_info?video_id=";




        public Task<VideoDownloadInfo> GetContentUriAsync(string contentId)
        {
            throw new NotImplementedException();
        }

        public void SuggestFileTypes(params FileTypeEnum[] suggestions)
        {
            throw new NotImplementedException();
        }

        public void SuggestMimeTypes(params MimeTypeEnum[] suggestions)
        {
            throw new NotImplementedException();
        }
    }


    // Helper methods for VideoInfoParser.
    static class VideoInfoParserHelpers
    {
        // Patterns use positive lookbehind and lazy modifier positive lookahead ("C# 5.0 In a Nutshell" by the Albahari brothers (p.998))
        const string BasicItagPattern = @"itag=\d{1,3}";                // match "itag=ddd"   return "itag=ddd"
        
        
        // Parses 'input' for the first instance of an query parameter "itag".
        public static bool TryParseUrlForItag(string input, out string output)
        {
            const string ItagPattern1 = @"(?<=\x3F)itag=\d{1,3}?(?=\x26)";  // match "?itag=ddd&" return "itag=ddd"
            const string ItagPattern2 = @"(?<=\x26)itag=\d{1,3}?(?=\x26)";  // match "&itag=ddd&" return "itag=ddd"
            const string ItagPattern3 = @"(?<=\x26)itag=\d{1,3}";           // match "&itag=ddd"  return "itag=ddd"
        }

        // Safely cast from a string to 'Resources.MediaQualityEnum'.  Relies on the int value of each enum member within 'MediaQualityEnum'.
        public static MediaQualityEnum MaptoItag(string input)
        {
            const string ItagValuePattern = @"(?<=itag=)\d{1,3}";           // match "itag=ddd"   return "ddd"
        }
    }
}
