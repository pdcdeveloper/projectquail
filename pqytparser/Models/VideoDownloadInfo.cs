using pqytparser.Resources;
using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public readonly string ContentId;
        public readonly string ContentTitle;

        public readonly VideoAvailabilityEnum Availability;
        public readonly string ErrorMessage;

        public readonly List<VideoMetadata> Videos;

        public VideoDownloadInfo(VideoAvailabilityEnum availability, string contentId, string contentTitle, string errorMessage, List<VideoMetadata> videos)
        {
            Availability = availability;
            ContentId = contentId;
            ContentTitle = contentTitle;
            ErrorMessage = errorMessage;
            Videos = (videos?.Count ?? 0) > 0 ? new List<VideoMetadata>(videos) : null;
        }
    }
}
