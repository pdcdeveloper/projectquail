using pqreflection;
using System;
using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    // The members of this enumeration also contain within its 'DisplayAttribute.ShortName' its corresponding file extension.
    // List of MIME types from Mozilla (use as guidance for creating custom MIME types):
    // <see cref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types"/>
    public enum FileTypeEnum : int
    {
        [Display(Name = "0", ShortName = "0", Description = "0")]
        Unknown = 0,

        [Display(ShortName = FileExtensions.Mp4)]
        Mp4,

        [Display(ShortName = FileExtensions.M4a)]
        M4a,

        [Display(ShortName = FileExtensions.Gggp)]
        Gggp,

        [Display(ShortName = FileExtensions.Flv)]
        Flv,

        [Display(ShortName = FileExtensions.Webm)]
        Webm
    }


    public static class FileTypeEnumHelpers
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
    }
}
