using System.Collections.Generic;

namespace VkApiLibrary.Factory.Models
{
    public class VkResponse<T>
    {
        public long Count { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
