using pqytparser.Resources;

namespace pqytparser.Models
{
    public struct VideoAvailability
    {
        public readonly VideoAvailabilityEnum Availability;

        // When 'Availability' is not set as 'VideoAvailabilityEnum.Available', check this for more details.
        public readonly string ErrorMessage;

        public VideoAvailability(VideoAvailabilityEnum availability, string errorMessage)
        {
            Availability = availability;
            ErrorMessage = errorMessage;
        }
    }
}