using Newtonsoft.Json;

namespace BotaniFinder.Models
{
    public class Date
    {
        public int DateId { get; set; }
        //public DateTime DateTaken { get; set; }

        // Navigation 
        public List<Image> Images { get; set; }
    }
}
