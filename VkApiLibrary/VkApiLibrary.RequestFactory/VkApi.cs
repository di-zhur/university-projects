using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VkApiLibrary.Factory.Interfaces;
using VkApiLibrary.Factory.Methods;
using VkApiLibrary.Factory.Models;

namespace VkApiLibrary.Factory
{
    public class VkApi : IVkApi
    {
        public IDatabase Database { get; }

        public IFriends Friends { get; }

        public VkApi()
        {
            Database = new Database(this);
            Friends = new Friends(this);
        }
        
        internal VkResponse<T> GetResponse<T>(string url)
        {
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var resultQuery = webClient.DownloadString(url);

                // if (resultQuery == null)
                //     throw new System.Exception("");

                var json = JObject.Parse(resultQuery);
                var response = json["response"].ToString();
                var result = JsonConvert.DeserializeObject<VkResponse<T>>(response);
                return result;
            }
        }
    }
}
