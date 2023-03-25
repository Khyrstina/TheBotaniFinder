using MessagePack;
using Newtonsoft.Json;

namespace BotaniFinder.Models
{
    public class Family
    {
        //JsonProperty is used to specify the name of the property in the JSON object.
        [JsonProperty("scientificNameWithoutAuthor")]
        public string ScientificNameWithoutAuthor { get; set; }

        [JsonProperty("scientificNameAuthorship")]
        public string ScientificNameAuthorship { get; set; }

        [JsonProperty("scientificName")]
        public string ScientificName { get; set; }
        public int FamilyId { get; set; }
        public Species Species { get; set; }
        public int SpeciesId { get; set; }
    }
}
