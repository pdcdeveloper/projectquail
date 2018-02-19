using System.Collections.Generic;

namespace pqytparser.Models
{
    public class VideoDownloadInfo
    {
        public VideoAvailability Availability { get; }
        public IList<VideoMetadata> Videos { get; }
        public string ContentId { get; }

        public VideoDownloadInfo(string contentId)
        {
            ContentId = contentId;
        }
    }
}
