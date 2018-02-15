using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqytparser.Models
{
    public struct VideoAvailability
    {
        public VideoAvailabilityEnum Availability { get; }

        // When 'Availability' is not set as VideoAvailabilityEnum.Available, check this for more details.
        public string ErrorMessage { get; }
    }
}
