namespace VkApiLibrary.Types
{
    public class Response<T>
    {
        public long Count { get; set; }

        public T Items { get; set; }
    }
}
