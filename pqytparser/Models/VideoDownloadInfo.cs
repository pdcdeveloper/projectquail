using pqytparser.Resources;
using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public readonly string ContentId;

        public readonly VideoAvailability ParserResult;
        public readonly List<VideoMetadata> Videos;

        public VideoDownloadInfo(string contentId, VideoAvailability parserResult, List<VideoMetadata> videos)
        {
            ContentId = contentId;
            ParserResult = parserResult;
            Videos = ParserResult.Availability == VideoAvailabilityEnum.Available ? new List<VideoMetadata>(videos) : null;
        }
    }
}
