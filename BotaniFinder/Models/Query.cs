using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotaniFinder.Models
{
    public class Query
    {
        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("organs")]
        public List<string> Organs { get; set; }

        [JsonProperty("includeRelatedImages")]
        public bool IncludeRelatedImages { get; set; }
    }
}
