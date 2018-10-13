using Newtonsoft.Json;
using VkApiLibrary.Factory.Interfaces;

namespace VkApiLibrary.Factory.Models
{
    public class FriendsGet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }

        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
