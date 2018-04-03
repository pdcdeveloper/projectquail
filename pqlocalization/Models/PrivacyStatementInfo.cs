using Newtonsoft.Json;

namespace pqlocalization.Models
{
    public class PrivacyStatementInfo
    {
        [JsonProperty(nameof(PrivacyStatement))]
        public string PrivacyStatement { get; set; }
    }
}
