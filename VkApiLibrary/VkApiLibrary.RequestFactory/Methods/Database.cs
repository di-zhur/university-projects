using System.Collections.Generic;
using VkApiLibrary.Factory.Interfaces;
using VkApiLibrary.Factory.Models;

namespace VkApiLibrary.Factory.Methods
{
    public class Database : IDatabase
    {
        private readonly VkApi _vkApi;

        public Database(VkApi vkApi)
        {
            _vkApi = vkApi;
        }

        public VkResponse<GetCountries> GetCountries()
        {
            var url = new VkUrl("database.getCountries").Get(typeof(GetCountries));
            return _vkApi.GetResponse<GetCountries>(url);
        }
    }
}
