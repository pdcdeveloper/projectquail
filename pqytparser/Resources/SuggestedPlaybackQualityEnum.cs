using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
    // This enumeration is based on YouTube's player api and may determine which resolution the YouTube html5 player should attempt to playback.
    // Passing in a member to YouTube's player api (as a string using its 'DisplayAttribute.Name' property,) is one of the factors (besides browser playback support,)
    // that affects the download url chosen by YouTube's html5 player.  Take note that passing in this parameter to YouTube's player api is
    // only a suggestion and the playback quality chosen by the YouTube html5 player is based on availability.
    public enum SuggestedPlaybackQualityEnum : int
    {
        [Display(Name = "default")]
        Default = 0,

        [Display(Name = "small")]
        Small,

        [Display(Name = "medium")]
        Medium,

        [Display(Name = "large")]
        Large,

        [Display(Name = "hd720")]
        HD720,

        [Display(Name = "hd1080")]
        HD1080,

        [Display(Name = "highres")]
        HighRes
    }
}
