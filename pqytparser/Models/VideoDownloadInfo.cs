using pqytparser.Resources;
using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public readonly string ContentId;
        public readonly string ContentTitle;

        public readonly VideoAvailability Result;
        public readonly List<VideoMetadata> Videos;

        public VideoDownloadInfo(string contentId, string contentTitle, VideoAvailability parserResult, List<VideoMetadata> videos)
        {
            ContentId = contentId;
            ContentTitle = contentTitle;
            Result = parserResult;
            Videos = (videos?.Count ?? 0) > 0 ? new List<VideoMetadata>(videos) : null;
        }
    }
}
