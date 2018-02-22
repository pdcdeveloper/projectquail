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
        IVideoInfoDomDecoder decoder;

        public VideoInfoParser()
        {
            decoder = new VideoInfoDomDecoder();
        }

        public async Task<VideoDownloadInfo> GetContentUriAsync(string contentId, string contentTitle, IList<MimeTypeEnum> mimeTypes, IList<FileTypeEnum> fileTypes)
        {
            if (string.IsNullOrEmpty(contentId) || string.IsNullOrEmpty(contentTitle))
                return new VideoDownloadInfo(null, null, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Content id was not set."), null);

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

            // Decode and parse.
            string dom = await decoder.GetVideoInfoDomAsync(contentId);
            if (string.IsNullOrEmpty(dom))
                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Failed to retrieve the dom"), null);
            return decoder.GetVideoDownloadInfo(contentId, contentTitle, dom);
        }
    }
}
