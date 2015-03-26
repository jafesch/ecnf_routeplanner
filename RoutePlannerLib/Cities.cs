using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System.Globalization;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public int Count { get { return cities.Count; } }
        List<City> cities = new List<City>();

        //Lab3 1
        public City FindCity(string cityName)
        {
            return cities.Find(c => String.Compare(c.Name, cityName, true) == 0);
        }

        public int ReadCities(string filename)
        {
            using (TextReader reader = new StreamReader(filename))
            {
                IEnumerable<string[]> citiesAsStrings = reader.GetSplittedLines('\t');
                IEnumerable<City> c = citiesAsStrings.Select(city => new City(city[0].ToString(), city[1].ToString(), int.Parse(city[2]), double.Parse(city[3]) ,double.Parse(city[4]))).ToList();
                cities.AddRange(c);
                return c.Count();
            }
            
        }

        public City this[int i]
        {
            get
            {
                if (i < Count) { return cities[i]; } else { return null; }
            }
        }

        public List<City> FindNeighbours(WayPoint location, double distance)
        {
            IEnumerable<City> citiesTemp = cities.Where(c => location.Distance(c.Location) <= distance).ToList(); ;

            return (List<City>)citiesTemp;
        }

        #region Lab04: FindShortestPath helper function
        /// <summary>
        /// Find all cities between 2 cities 
        /// </summary>
        /// <param name="from">source city</param>
        /// <param name="to">target city</param>
        /// <returns>list of cities</returns>
        public List<City> FindCitiesBetween(City from, City to)
        {
            var foundCities = new List<City>();
            if (from == null || to == null)
                return foundCities;

            foundCities.Add(from);

            var minLat = Math.Min(from.Location.Latitude, to.Location.Latitude);
            var maxLat = Math.Max(from.Location.Latitude, to.Location.Latitude);
            var minLon = Math.Min(from.Location.Longitude, to.Location.Longitude);
            var maxLon = Math.Max(from.Location.Longitude, to.Location.Longitude);

            foundCities.AddRange(cities.FindAll(c =>
                c.Location.Latitude > minLat && c.Location.Latitude < maxLat
                        && c.Location.Longitude > minLon && c.Location.Longitude < maxLon));

            foundCities.Add(to);
            return foundCities;
        }
        #endregion
    }
}
