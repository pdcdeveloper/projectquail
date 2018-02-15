using System.ComponentModel.DataAnnotations;

namespace pqytparser.Resources
{
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
