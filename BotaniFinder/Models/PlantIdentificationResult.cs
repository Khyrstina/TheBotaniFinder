using MessagePack;
using Newtonsoft.Json;
using Plant.NET.Models;
using System.ComponentModel.DataAnnotations;

namespace BotaniFinder.Models
{
    public class PlantIdentificationResult
    {
        [JsonProperty("id")]
        [System.ComponentModel.DataAnnotations.Key]
        public int PlantIdentificationId { get; set; }
        [JsonProperty("score")]
        public Double Score { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("images")]
        public List<Image> Image { get; set; }

        //[JsonProperty("gbif")]
        //public Gbif Gbif { get; set; }
        public int Family { get; set; }
        public int SpeciesId { get; set; }
        public int FamilyId { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string CommonNames { get; set; }
        public int ImageDate { get; set; }
        public string FamilyScientificNameWithoutAuthor { get; internal set; }
        public string GenusScientificNameWithoutAuthor { get; internal set; }
        public string SpeciesScientificNameWithoutAuthor { get; internal set; }
        public float ScorePercentage { get; internal set; }
    }
}
