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
            List<List<string>> listRoutes = new List<List<string>>();
            List<string> finalRoutes = new List<string>();

            string[] delimiter = { "->" };

            foreach (string route in routes)
            {
                string[] pages = route.Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries);
                List<string> listPages = pages.ToList();
                List<string> trimmedList = new List<string>();
                foreach (string page in listPages)
                {
                    string trimedPage = page.Trim();
                    trimmedList.Add(trimedPage);
                }
                listRoutes.Add(trimmedList);
            }
            try
            {
                for (int i = 0; i < listRoutes.Count(); i++)
                {
                    List<string> currentRoute = listRoutes.ElementAt(i);

                    if (currentRoute.Count() > 1)
                    {
                        for (int j = 0; j < listRoutes.Count(); j++)
                        {
                            List<string> compareRoute = listRoutes.ElementAt(j);
                            if (compareRoute.Count() > 0)
                            {
                                if (currentRoute.Last() == compareRoute.First())
                                {
                                    if (i == j)
                                    {
                                        throw new CircularReferenceException();
                                    }
                                    else
                                    {
                                        currentRoute.RemoveAt(currentRoute.Count() - 1);
                                        currentRoute.AddRange(compareRoute);
                                        compareRoute.Clear();
                                        j = 0;
                                    }

                                }
                            }
                        }
                    }
                }

                foreach (List<string> routeList in listRoutes)
                {
                    if (routeList.Count() > 0)
                    {
                        StringBuilder assembleRoute = new StringBuilder();
                        for (int i = 0; i < (routeList.Count() - 1); i++)
                        {
                            assembleRoute.Append(routeList.ElementAt(i));
                            assembleRoute.Append(" -> ");
                        }
                        assembleRoute.Append(routeList.Last());
                        finalRoutes.Add(assembleRoute.ToString());
                    }
                }
            }
            catch (CircularReferenceException e)
            {
                finalRoutes.Clear();
                finalRoutes.Add(e.Message);
            }
            return finalRoutes;
        }
    }
}
