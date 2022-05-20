using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Exercise
{
    interface RouteAnalyzer
    {
        IEnumerable<string> Process(IEnumerable<string> routes);
    }
}
