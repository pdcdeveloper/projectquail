using pqytparser.Resources;
using System;

namespace pqytparser.Models
{
    public struct VideoMetadata
    {
        public string ContentId { get; }
        public string DownloadUrl { get; }

        public MediaQualityEnum Quality { get; }

        public FileTypeEnum GetFileType()
        {
            if (Quality == MediaQualityEnum.Unknown)
                return FileTypeEnum.Unknown;
            //todo
            foreach (FileTypeEnum ft in Enum.GetValues(typeof(FileTypeEnum)))
                ;
            return FileTypeEnum.Unknown;
        }


        //public FileTypeEnum FileExt { get; }
        //public MimeTypeEnum MimeType { get; }
    }
}
