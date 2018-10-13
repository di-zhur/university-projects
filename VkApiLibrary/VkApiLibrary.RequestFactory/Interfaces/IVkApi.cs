using VkApiLibrary.Factory.Methods;

namespace VkApiLibrary.Factory.Interfaces
{
    public interface IVkApi
    {
        IDatabase Database { get; }

        IFriends Friends { get; }
    }
}