using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    /// <summary>
    /// The members of this enumeration also contain within its DisplayAttribute.Description its string representation.
    /// </summary>
    /// <remarks>
    /// <see cref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types"/>
    /// </remarks>
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
}
