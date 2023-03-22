using Newtonsoft.Json;
using Plant.NET.Models;

namespace BotaniFinder.Models
{
    public class Species : Taxon
    {
        public int SpeciesId { get; set; }
        [JsonProperty("scientificNameWithoutAuthor")]
        public string ScientificNameWithoutAuthor { get; set; }

        [JsonProperty("scientificNameAuthorship")]
        public string ScientificNameAuthorship { get; set; }

        [JsonProperty("scientificName")]
        public string ScientificName { get; set; }

        [JsonProperty("genus")]
        public Genus Genus { get; set; }

        [JsonProperty("family")]
        public Family Family { get; set; }

        [JsonProperty("commonNames")]
        public List<string> CommonNames { get; set; }
        public int FamilyId { get; set; }
    }
}
