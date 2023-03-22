using Newtonsoft.Json;

namespace BotaniFinder.Models
{
    public class Gbif
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
