using Newtonsoft.Json;

namespace pqlocalization.Models
{
    public struct ContactInfo
    {
        [JsonProperty(nameof(DeveloperName))]
        public string DeveloperName { get; set; }

        [JsonProperty(nameof(Email))]
        public string Email { get; set; }
    }
}
