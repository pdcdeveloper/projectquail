using pqytparser.Resources;

namespace pqytparser.Models
{
    public struct VideoAvailability
    {
        public VideoAvailabilityEnum Availability { get; }

        // When 'Availability' is not set as 'VideoAvailabilityEnum.Available', check this for more details.
        public string ErrorMessage { get; }
    }
}
