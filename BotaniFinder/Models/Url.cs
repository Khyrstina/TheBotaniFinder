using Newtonsoft.Json;

namespace BotaniFinder.Models
{
    public class Url
    {
        public int UrlId { get; set; }
        [JsonProperty("o")]
        public string O { get; set; }

        [JsonProperty("m")]
        public string M { get; set; }

        [JsonProperty("s")]
        public string S { get; set; }

    }
}
