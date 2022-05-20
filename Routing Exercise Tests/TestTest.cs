using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routing_Exercise;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Routing_Exercise_Tests
{
   
    [TestClass]
    public class RedirectTest
    {
        RedirectEngine engine;
        
        List<string> expectedRoutes;
        List<string> usedRoutes;
        string[] testStrings;
        IEnumerable resultStrings;
        
        int routeCount;
        int expectedCount;

        [TestInitialize]
        public void SetUp()
        {
            engine = new RedirectEngine();

            expectedCount = 4;
            expectedRoutes = new List<string>();
            expectedRoutes.Add("/home");
            expectedRoutes.Add("/our-ceo.html -> /about-us.html");
            expectedRoutes.Add("/about-us.html -> /about");
            expectedRoutes.Add("/product-1.html -> /seo");
            
            testStrings = new string[4]
           {
                "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
           };

            usedRoutes = new List<string>();

        }

        [TestMethod]
        public void PassThrough()
        {           

            resultStrings = engine.Process(testStrings);

            foreach(string route in resultStrings)
            {
                Assert.IsFalse(usedRoutes.Contains(route));
                usedRoutes.Add(route);
                routeCount++;
                Assert.IsTrue(expectedRoutes.Contains(route));
            }
            Assert.AreEqual(expectedCount, routeCount);
        }
    }
}
