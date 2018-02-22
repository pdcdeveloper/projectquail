using pqytparser.Resources;
using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public readonly string ContentId;

        public readonly VideoAvailability Result;
        public readonly List<VideoMetadata> Videos;

        public VideoDownloadInfo(string contentId, VideoAvailability parserResult, List<VideoMetadata> videos)
        {
            ContentId = contentId;
            Result = parserResult;
            Videos = Result.Availability == VideoAvailabilityEnum.Available ? new List<VideoMetadata>(videos) : null;
        }
    }
}
