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
        public readonly MimeTypeEnum MimeType;
        public readonly FileTypeEnum FileType;
        public readonly string FileExt;

        public readonly string DownloadUrl;


        public VideoMetadata(string contentId, string contentTitle, MediaQualityEnum quality, string downloadUrl)
        {
            ContentId = contentId;
            ContentTitle = contentTitle;
            Quality = quality;
            MimeType = Quality.GetMimeType();
            FileType = Quality.GetFileType();
            FileExt = Quality.GetShortName();

            DownloadUrl = downloadUrl;
        }
    }

    // The static methods of this class should only ever be used by the 'VideoMetadata' model.
    static class VideoMetaDataHelpers
    {
        public static FileTypeEnum GetFileType(this MediaQualityEnum quality)
        {
            if (quality == MediaQualityEnum.Unknown)
                return FileTypeEnum.Unknown;
            foreach (FileTypeEnum ft in Enum.GetValues(typeof(FileTypeEnum)))
                if (quality.GetShortName().ToLower() == ft.GetShortName().ToLower())
                    return ft;
            return FileTypeEnum.Unknown;
        }

        public static MimeTypeEnum GetMimeType(this MediaQualityEnum quality)
        {
            if (quality == MediaQualityEnum.Unknown)
                return MimeTypeEnum.Unknown;
            foreach (MimeTypeEnum mt in Enum.GetValues(typeof(MimeTypeEnum)))
                if (quality.GetDescription().ToLower() == mt.GetDescription().ToLower())
                    return mt;
            return MimeTypeEnum.Unknown;
        }
    }

}
