using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiLibrary.Factory.Interfaces;
using VkApiLibrary.Factory.Models;

namespace VkApiLibrary.Factory.Methods
{
    public class Friends : IFriends
    {
        private readonly VkApi _vkApi;

        public Friends(VkApi vkApi)
        {
            _vkApi = vkApi;
        }

        public VkResponse<FriendsGet> Get(FriendsGetParams paramsQuery)
        {
            var url = new VkUrl("friends.get").Get(typeof(FriendsGet), paramsQuery);
            return _vkApi.GetResponse<FriendsGet>(url);
        }
    }
}
