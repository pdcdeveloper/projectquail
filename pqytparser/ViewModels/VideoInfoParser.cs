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
    public class VideoInfoParser : IVideoInfoParser
    {
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

            // Parse
        }
    }
}
