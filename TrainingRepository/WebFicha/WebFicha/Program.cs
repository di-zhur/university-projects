using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;

namespace WebFicha
{
    public class User
    {
        public long Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Sex { get; set; }
        public string Photo_50 { get; set; }
    }

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



    class Program
    {
        static void Main(string[] args)
        {
            var subscriptions = GetVKSubscriptionsById(41071787);
            var friends = GetVKFriendsById(41071787);
            var friendsInFriends = new ConcurrentDictionary<long, List<User>>();
            Parallel.ForEach(friends, (friend) => 
            {
                var hisFriends = GetVKFriendsById(friend.Id);
                friendsInFriends.GetOrAdd(friend.Id, hisFriends);
            });
           
            Console.ReadKey();
        }
        

        public static List<User> GetVKFriendsById(long userId)
        {
            var request =
                (HttpWebRequest)WebRequest.Create(
                    $"https://api.vk.com/method/friends.get" +
                    $"?user_id={userId}" +
                    $"&fields=photo_50,city,sex,career" +
                    $"&v=5.69");
            request.Method = "GET";
            request.Accept = "application/json";

            var users = new List<User>();
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var readResult = reader.ReadToEnd();
                var items = JObject.Parse(readResult)["response"]["items"]?.ToString();
                users = JsonConvert.DeserializeObject<List<User>>(items);
                response.Close();
            }

            return users;
        }

        /*
         photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, wall_comments, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me
             */

        public static List<Subscription> GetVKSubscriptionsById(long userId)
        {
            var request =
                (HttpWebRequest)WebRequest.Create(
                    $"https://api.vk.com/method/users.getSubscriptions?user_id={userId}&extended=1&v=5.69");
            request.Method = "GET";
            request.Accept = "application/json";

            var subscriptions = new List<Subscription>();
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var readResult = reader.ReadToEnd();
                var items = JObject.Parse(readResult)["response"]["items"]?.ToString();
                subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(items);
                response.Close();
            }

            return subscriptions;
        }
    }
}
