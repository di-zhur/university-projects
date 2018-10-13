namespace VkApiLibrary.Factory.Models
{
    public class Subscription
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Screen_name { get; set; }

        public int Is_closed { get; set; }

        public string Type { get; set; }

        public int Is_admin { get; set; }

        public int Is_member { get; set; }

        public string Photo_50 { get; set; }

        public string Photo_100 { get; set; }

        public string Photo_200 { get; set; }
    }
}
