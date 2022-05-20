using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routing_Exercise;
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
    }

    [TestClass]
    public class RedirectTest
    {
        [TestMethod]
        public void PassThrough()
        {
            RedirectEngine engine = new RedirectEngine();

            string[] testStrings = new string[4] 
            {
                "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            string[] resultStrings = (string[])engine.Process(testStrings);

            Assert.AreEqual(testStrings, resultStrings);

        }
    }
}
