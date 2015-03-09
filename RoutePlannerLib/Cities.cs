using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public int Count { get { return cities.Count; } }
        List<City> cities = new List<City>();

        //Lab3 1
        public City FindCity(string cityName)
        {
            Predicate<City> predicateDelegate = delegate(City city)
            {
                return String.Compare(city.Name, cityName, true) == 0;
            };

            return cities.Find(predicateDelegate);
        }

        public int ReadCities(string filename)
        {
            int count = 0;

            TextReader reader = File.OpenText(filename);

            String s;
            Char[] separator = { '\t' };
            City city;
            while ((s = reader.ReadLine()) != null)
            {
                count++;
                city = new City(s.Split(separator)[0],
                    s.Split(separator)[1],
                    int.Parse(s.Split(separator)[2]),
                    double.Parse(s.Split(separator)[3]),
                    double.Parse(s.Split(separator)[4])
                    );
                cities.Add(city);
            }
            return count;
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
            List<City> citiesTemp = new List<City>();
            for (int i = 0; i < cities.Count; i++)
            {
                if (location.Distance(cities[i].Location) <= distance)
                {
                    citiesTemp.Add(cities[i]);
                }
            }

            return citiesTemp;
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
