using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Delta.Analytics;

namespace Delta.UnitTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod()
        {
            var test = new FrecastExecutor(3, null);
            test.Do();

        }
    }
}
