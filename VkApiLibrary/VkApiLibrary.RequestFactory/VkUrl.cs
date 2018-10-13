using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace VkApiLibrary.Factory
{
    /// <summary>
    /// Создать url
    /// </summary>
    internal class VkUrl
    {
        /// <summary>
        /// Версия Api
        /// </summary>
        private const string _version = "5.69";

        private readonly string _mainPartUrl;

        public VkUrl(string methodName)
        {
            _mainPartUrl = $"https://api.vk.com/method/{methodName}";
        }

        /// <summary>
        /// Получить url
        /// </summary>
        /// <param name="typeFields"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string Get(Type typeFields, object paramsQuery = null)
        {
            var queryFields = string.Join(",", 
                typeFields.GetProperties().
                Select(o => (o.GetCustomAttributes(typeof(JsonPropertyAttribute)).
                FirstOrDefault() as JsonPropertyAttribute)?.PropertyName));

            if (paramsQuery != null)
            {
                var parameters = string.Join(",", paramsQuery?.GetType().GetProperties()
                    .Select(p => $"{p.Name.ToLower()}={p.GetValue(paramsQuery)}"));

                return $"{_mainPartUrl}?{parameters}&fields={queryFields}&v={_version}";
            }

            return $"{_mainPartUrl}?fields={queryFields}&v={_version}";
        }
    }
}
