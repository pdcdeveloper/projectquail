using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqytparser.Models
{
    public struct VideoMetadata
    {
        public string ContentId { get; }
        public string DownloadUrl { get; }

        public MediaQualityEnum Quality { get; }
        public MimeTypeEnum MimeType { get; }
        public ContentTypeEnum ContentType { get; }
        //todo
    }
}
