
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System.Diagnostics;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public delegate void RouteRequestHandler(object sender, RouteRequestEventArgs e);

    /// <summary>
    /// Manages a routes from a city to another city.
    /// </summary>
    public abstract class Routes : IRoutes
    {
        protected List<Link> routes = new List<Link>();
        protected Cities cities;
        private static readonly TraceSource traceSource = new TraceSource("Routes");
        private static readonly TraceSource traceSourceErrors = new TraceSource("RoutesErrors");

        public abstract event RouteRequestHandler RouteRequestEvent;

        public bool ExecuteParallel { set; get; }

        public int Count
        {
            get { return routes.Count; }
        }

        public Routes() { }

        /// <summary>
        /// Initializes the Routes with the cities.
        /// </summary>
        /// <param name="cities"></param>
        public Routes(Cities cities)
        {
            this.cities = cities;
        }

        /// <summary>
        /// Reads a list of links from the given file.
        /// Reads only links where the cities exist.
        /// </summary>
        /// <param name="filename">name of links file</param>
        /// <returns>number of read route</returns>
        public int ReadRoutes(string filename)
        {
            try {
                using (TextReader reader = new StreamReader(filename))
                {
                    traceSource.TraceInformation("Read Routes started");
                    traceSource.Flush();
                    IEnumerable<string[]> linkAsString = reader.GetSplittedLines('\t');
                    foreach (string[] ls in linkAsString)
                    {
                        City city1 = cities.FindCity(ls[0]);
                        City city2 = cities.FindCity(ls[1]);

                        // only add links, where the cities are found 
                        if ((city1 != null) && (city2 != null))
                        {
                            routes.Add(new Link(city1, city2, city1.Location.Distance(city2.Location),
                                TransportModes.Rail));
                        }
                    }
                    traceSource.TraceInformation("Read Routes ended");
                    traceSource.Flush();
                    return Count;
                }

            }
            catch (FileNotFoundException e)
            {
                traceSourceErrors.TraceData(TraceEventType.Critical, 1, e.StackTrace);
                traceSource.Flush();
            }
            return -1;
        }

        public City[] FindCities(TransportModes transportMode)
        {
            return routes.Where(r1 => r1.TransportMode == transportMode)
                         .SelectMany(r2 => new[] { r2.FromCity, r2.ToCity })
                         .Distinct()
                         .ToArray();
        }

        public abstract List<Link> FindShortestRouteBetween(string fromCity, string toCity, TransportModes mode);
    }
}
