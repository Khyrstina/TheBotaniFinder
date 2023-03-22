using Newtonsoft.Json;
using Plant.NET.Models;
using System.Text.Json.Serialization;

namespace BotaniFinder.Models
{
    public class Root
    {
        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("preferedReferential")]
        public string PreferedReferential { get; set; }

        [JsonProperty("switchToProject")]
        public string SwitchToProject { get; set; }

        [JsonProperty("bestMatch")]
        public string BestMatch { get; set; }

        [JsonProperty("results")]
        public List<PlantIdentificationResult> Results { get; set; }
        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("remainingIdentificationRequests")]
        public int RemainingIdentificationRequests { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

    }
}
