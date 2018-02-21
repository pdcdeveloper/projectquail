﻿using pqytparser.Interfaces;
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

        public async Task<VideoDownloadInfo> GetContentUriAsync(string contentId, IList<MimeTypeEnum> mimeTypes, IList<FileTypeEnum> fileTypes)
        {
            if (string.IsNullOrEmpty(contentId))
                return new VideoDownloadInfo(string.Empty, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Content id was not set."), null);

            // Check for unknown mime and file types.
            if ((mimeTypes?.Count ?? 0) < 1 || mimeTypes.Contains(MimeTypeEnum.Unknown))
            {
                mimeTypes.Clear();
                mimeTypes.Add(MimeTypeEnum.Audio);
                mimeTypes.Add(MimeTypeEnum.MuxedAudioVideo);
            }

            if ((fileTypes?.Count ?? 0) < 1 || fileTypes.Contains(FileTypeEnum.Unknown))
            {
                fileTypes.Clear();
                fileTypes.Add(FileTypeEnum.M4a);
                fileTypes.Add(FileTypeEnum.Mp4);
                fileTypes.Add(FileTypeEnum.Webm);
            }

            //
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
