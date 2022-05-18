using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Routing_Exercise_Tests
{
    [TestClass]
    public class TestTest
    {
        [TestMethod]
        public void TestPass()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestFail()
        {
            Assert.IsFalse(true);
        }
    }
}
