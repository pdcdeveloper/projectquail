using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    /// <summary>
    /// The members of this enumeration also contain within its DisplayAttribute.ShortName its corresponding file extension.
    /// </summary>
    /// <remarks>
    /// <see cref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types"/>
    /// </remarks>
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
}
