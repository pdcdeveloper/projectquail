using pqytparser.Resources;
using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public readonly string ContentId;
        public readonly string ContentTitle;

        public readonly VideoAvailability Status;
        public readonly List<VideoMetadata> Videos;

        public VideoDownloadInfo(string contentId, string contentTitle, VideoAvailability status, List<VideoMetadata> videos)
        {
            ContentId = contentId;
            ContentTitle = contentTitle;
            Status = status;
            Videos = (videos?.Count ?? 0) > 0 ? new List<VideoMetadata>(videos) : null;
        }
    }
}
