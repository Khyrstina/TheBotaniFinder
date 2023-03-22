using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BotaniFinder.Models
{
    public class Genus
    {
        [Key] public int GenusId { get; set; }
        [JsonProperty("scientificNameWithoutAuthor")]
        public string ScientificNameWithoutAuthor { get; set; }

        [JsonProperty("scientificNameAuthorship")]
        public string ScientificNameAuthorship { get; set; }

        [JsonProperty("scientificName")]
        public string ScientificName { get; set; }
    }
}
