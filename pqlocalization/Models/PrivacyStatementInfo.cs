using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqlocalization.Models
{
    public class PrivacyStatementInfo
    {
        [JsonProperty(nameof(PrivacyStatement))]
        public string PrivacyStatement { get; set; }
    }
}
