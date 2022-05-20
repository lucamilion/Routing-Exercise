using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            RedirectEngine engine = new RedirectEngine();

            string[] testStrings = new string[]
            {
                "/home",
                "/about -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            IEnumerable resultStrings = engine.Process(testStrings);

            foreach(string s in resultStrings)
            {
                Console.WriteLine(s);
            } 

            Console.ReadLine();

        }
    }
}
