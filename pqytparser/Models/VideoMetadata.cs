using System;
using pqytparser.Resources;
using pqlib.Reflection.Attributes;

namespace pqytparser.Models
{
    public struct VideoMetadata
    {
        public readonly MediaQualityEnum Quality;
        public readonly MimeTypeEnum MimeType;
        public readonly string FileExt;

        public string ContentId;
        public string DownloadUrl;


        public VideoMetadata(MediaQualityEnum quality)
        {
            Quality = quality;
            FileExt = Quality.GetShortName();
            MimeType = Quality.GetMimeType();

            ContentId = string.Empty;
            DownloadUrl = string.Empty;
        }

        public VideoMetadata(string contentId, MediaQualityEnum quality) : this(quality)
        {
            ContentId = contentId;
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
