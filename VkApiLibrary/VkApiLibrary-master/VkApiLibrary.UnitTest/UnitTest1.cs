using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using VkApiLibrary.Factory;
using VkApiLibrary.Factory.Models;
using VkApiLibrary.Factory.Interfaces;

namespace VkApiLibrary.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userId = 41071787;
            IVkApi api = new VkApi();
            var friends = api.Friends.Get(new FriendsGetParams() { User_Id = userId });
        }
    }
}
