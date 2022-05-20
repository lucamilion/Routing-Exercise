using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Exercise
{
    public class RedirectEngine : RouteAnalyzer
    {
        public IEnumerable<string> Process(IEnumerable<string> routes)
        {
            List<string> listRoutes = new List<string>();

            foreach(string route in routes)
            {
                listRoutes.Add(route);
            }
            return routes;
        }
    }
}
