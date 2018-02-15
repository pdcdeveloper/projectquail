using System.Collections.Generic;

namespace pqytparser.Models
{
    public struct VideoDownloadInfo
    {
        public VideoAvailability Availability { get; }
        public IList<VideoMetadata> Videos { get; }
    }
}
