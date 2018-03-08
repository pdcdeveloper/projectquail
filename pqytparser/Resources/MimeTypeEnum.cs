using pqlib.Reflection;
using System;
using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    // The members of this enumeration also contain within its 'DisplayAttribute.Description' its string representation.
    public enum MimeTypeEnum : int
    {
        [Display(Name = "0", ShortName = "0", Description = "0")]
        Unknown = 0,

        [Display(Description = MimeTypes.MuxedAudioVideo)]
        MuxedAudioVideo,

        [Display(Description = MimeTypes.Audio)]
        Audio,

        [Display(Description = MimeTypes.Video)]
        Video,

        [Display(Description = MimeTypes.Video3d)]
        Video3d,

        [Display(Description = MimeTypes.MuxedAudioVideo3d)]
        MuxedAudioVideo3d
    }


    public static class MimeTypeEnumHelpers
    {
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
