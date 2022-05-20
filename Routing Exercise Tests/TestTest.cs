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
            usedRoutes = new List<string>();
        }

        [TestMethod]
        public void DemoTest()
        {
            expectedCount = 3;
            expectedRoutes = new List<string>();
            expectedRoutes.Add("/home");
            expectedRoutes.Add("/our-ceo.html -> /about-us.html -> /about");
            expectedRoutes.Add("/product-1.html -> /seo");

            testStrings = new string[]
            {
                "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

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

        [TestMethod]
        public void ExceptionTest()
        {
            expectedCount = 1;
            expectedRoutes = new List<string>();
            expectedRoutes.Add("Exception of type 'Routing_Exercise.CircularReferenceException' was thrown.");

            testStrings = new string[]
            {
                "/home",
                "/about -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            resultStrings = engine.Process(testStrings);

            foreach (string route in resultStrings)
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
