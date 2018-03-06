using System;
using pqytparser.Resources;
using pqlib.Reflection.Attributes;

namespace pqytparser.Models
{
    public struct VideoMetadata
    {
        public readonly string ContentId;
        public readonly string ContentTitle;
        public readonly MediaQualityEnum Quality;
        public readonly int Itag;
        public readonly MimeTypeEnum MimeType;
        public readonly FileTypeEnum FileType;
        public readonly string FileExt;

        public readonly string DownloadUrl;


        public VideoMetadata(string contentId, string contentTitle, MediaQualityEnum quality, string downloadUrl)
        {
            ContentId = contentId;
            ContentTitle = contentTitle;
            Quality = quality;
            Itag = (int)Quality;
            MimeType = Quality.GetMimeType();
            FileType = Quality.GetFileType();
            FileExt = Quality.GetShortName();

            DownloadUrl = downloadUrl;
        }
    }
}
