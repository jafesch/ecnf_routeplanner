using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class RoutesFactory
    {
        static public IRoutes Create(Cities cities)
        {
            var routeAlgorithm = Properties.Settings.Default.RouteAlgorithm;
            return Create(cities, routeAlgorithm);
        }
        static public IRoutes Create(Cities cities, string algorithmClassName)
        {
            IRoutes routeFactory = null;
            Assembly a = Assembly.GetExecutingAssembly();
            Type t = a.GetType(algorithmClassName);

            if (t == null)
            {
                return null;
            }

            routeFactory = (IRoutes)Activator.CreateInstance(t, cities);
            return routeFactory as IRoutes;
        }
    }
}
