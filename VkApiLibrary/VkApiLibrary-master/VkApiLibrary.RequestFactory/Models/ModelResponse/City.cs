using Newtonsoft.Json;

namespace VkApiLibrary.Factory.Models
{
    public class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
