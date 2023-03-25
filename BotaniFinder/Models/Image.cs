using Newtonsoft.Json;
using System.Security.Policy;

namespace BotaniFinder.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [JsonProperty("organ")]
        public string Organ { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("citation")]
        public string Citation { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
        // This PlantIdentificationResult property is used to store the result of the plant identification.
        public PlantIdentificationResult PlantIdentificationResult { get; set; }
    }
}
