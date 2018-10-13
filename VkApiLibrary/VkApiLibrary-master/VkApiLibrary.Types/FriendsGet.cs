using System;
using System.Collections.Generic;
using System.Linq;
namespace VkApiLibrary.Types
{
    public class FriendsGet
    {
        public long Id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public int Sex { get; set; }

        public string Photo_100 { get; set; }

        public City City { get; set; }
    }
}
